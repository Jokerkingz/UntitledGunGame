using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Connect_System : MonoBehaviour
{
    [Header("Editor Setup")]
    public Transform vGameController;
    public Scr_Grabbable cGrabbablePart;
    public Transform vMainBody;
    public Scr_PartParenting[] vMainParts;
    public Vector3 vPositionOffset;
    public Vector3 vAngleOffset;
    


    [Header("Running")]
    public Scr_Socket_Female vConnectedToFemale;


    [ContextMenu("Reconstruct Prefab for system, and resets all part parenting after (Reset)")]
    private void Reset()
    {
        vGameController = GameObject.FindGameObjectWithTag("GameController").transform;
        vMainParts = this.GetComponentsInChildren<Scr_PartParenting>();
        cGrabbablePart = this.GetComponentInChildren<Scr_Grabbable>();
        
        Scr_PartParenting tTempPP;
        MeshCollider tTempMC;
        Scr_Socket_Male tTempSM;
        Scr_Socket_System tTempSS;
        tTempSS = this.GetComponentInChildren<Scr_Socket_System>();
        // Mainbody setup insurance
        vMainBody = this.GetComponentInChildren<MeshRenderer>().transform;
        if (vMainBody.transform.IsChildOf(this.transform))
        {
            // Check if there is a part parenting, if not fully setup main part
            tTempPP = vMainBody.GetComponent<Scr_PartParenting>();
            if (tTempPP == null)
            {
                vMainBody.tag = "Grabbable";
                tTempMC = vMainBody.GetComponent<MeshCollider>();
                if (tTempMC == null)
                    tTempMC = vMainBody.gameObject.AddComponent<MeshCollider>();
                tTempMC.convex = true;
            }

            // Add grabbable system
            if (vMainBody.GetComponent<Scr_Grabbable>() == null)
                cGrabbablePart = vMainBody.gameObject.AddComponent<Scr_Grabbable>();

            // Part parenting system, which is commonly used for connect system with sockets
            if (vMainBody.GetComponent<Scr_PartParenting>() == null)
                vMainBody.gameObject.AddComponent<Scr_PartParenting>();

            // if there is a socket male, setup main body to have the connect system
            tTempSM = this.GetComponentInChildren<Scr_Socket_Male>();
            if (tTempSM != null)
            {
                if (vMainBody.GetComponent<Scr_Socket_System>() == null)
                    cGrabbablePart.cSS = vMainBody.gameObject.AddComponent<Scr_Socket_System>();
            }
            cGrabbablePart.Reset();
            //
            //vMainBody
        } else
        {
            vMainBody = null;
            Debug.Log("The first child of this object is NOT the main body");
        }

        //
        Scr_Socket_Male tTemp = null;
        tTemp = this.GetComponentInChildren<Scr_Socket_Male>();
        //Debug.Log("vPositionOffset " + vPositionOffset.ToString());
        //Debug.Log("vPositionOffset *-1 " + vPositionOffset.ToString());
        ResetAllPartParenting();
        if (tTempSS != null)
            vAngleOffset = tTempSS.cSM.transform.localEulerAngles;
        if (tTemp != null)
            vPositionOffset = tTemp.transform.localPosition;
        vPositionOffset.x *= Mathf.Sign(vPositionOffset.x);
        vPositionOffset.y *= Mathf.Sign(vPositionOffset.y);
        vPositionOffset.z *= Mathf.Sign(vPositionOffset.z);
        vAngleOffset.y += -180;
        ResetAllPartParenting();
    }

    [ContextMenu("Reset All Part Parenting")]
    void ResetAllPartParenting()
    {
        foreach (Scr_PartParenting tPP in vMainParts)
        {
            tPP.Reset();
            tPP.SaveTransform();
        }
    }
    public void DetachSelf()
    {
        // Get The Top parent
        Scr_Connect_System tRoot = this.transform.root.gameObject.GetComponent<Scr_Connect_System>();

        // Update mechanism system if present

        if (vConnectedToFemale != null)
            vConnectedToFemale.vIsConnected = false;

        // Detach Self
        this.transform.SetParent(null);
        foreach (Scr_PartParenting tObj in vMainParts)
        {
            tObj.ResetParent();
            // Old Gameobject style parenting
            //tObj.transform.SetParent(this.gameObject.transform);
        }

        // Update Parent after removal
        if (tRoot != null)
        {
            if (tRoot != this)
            {
                tRoot.transform.SetParent(vGameController.transform);
                tRoot.transform.SetParent(null);
            }
        }
    }
    
    public void ConnectToSocket(Transform tSocket)
    {
        // Update Female Socket
        vConnectedToFemale = tSocket.GetComponent<Scr_Socket_Female>();
        vConnectedToFemale.vIsConnected = true;

        // Parent the prefab to align for positions and angle
        this.transform.SetParent(tSocket);
        this.transform.localPosition = Vector3.zero;
        this.transform.localEulerAngles = Vector3.zero;

        // Parent main body to connected socket
        vMainBody.transform.parent = tSocket;
        vMainBody.transform.localPosition = vPositionOffset;
        vMainBody.transform.localEulerAngles = vAngleOffset;

        // Follow up with the rest of the parts
        foreach (Scr_PartParenting tObj in vMainParts)
        {
            if (tObj.gameObject != vMainBody.gameObject)
                tObj.transform.parent = vMainBody;
        }
        
    }
}
