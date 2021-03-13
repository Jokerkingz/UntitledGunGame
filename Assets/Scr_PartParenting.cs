using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using sML = Scr_Master_Library;
public class Scr_PartParenting : MonoBehaviour
{
    public Transform vParent;
    public Transform vMaleSocket;
    public Vector3 vLocalPosition;
    //public Vector3 vSocketPosition;
    public Vector3 vEulerAngles;

    public void Reset()
    {
        Scr_Socket_Male tSM = this.transform.root.GetComponentInChildren<Scr_Socket_Male>();
        if (tSM != null)
        vMaleSocket = tSM.transform;
        //SaveTransform();
    }

    [ContextMenu("Save Information")]
    public void SaveTransform() // Editor only use
    {
        // Clean Transform IF IN EDITOR, polish own models' transform to have floats have less decimals and allow costum mods and meshes to be free
        //Scr_Connect_System tTemp; // Check if this has a main Connect system\
        Vector3 tVect3;
        if (Application.isEditor)
        {
            //tTemp = this.GetComponentInParent<Scr_Connect_System>();
            //if (tTemp != null) // if THIS is not the main object, clean up the transform
            //    if (tTemp.vMainBody.gameObject != this.gameObject)
            //    {
            tVect3 = this.transform.localScale;
            tVect3.x = sML.RoundToDecimalPlace(tVect3.x, 4);
            tVect3.y = sML.RoundToDecimalPlace(tVect3.y, 4);
            tVect3.z = sML.RoundToDecimalPlace(tVect3.z, 4);
            this.transform.localScale = tVect3;
            tVect3 = this.transform.localPosition;
            tVect3.x = sML.RoundToDecimalPlace(tVect3.x, 4);
            tVect3.y = sML.RoundToDecimalPlace(tVect3.y, 4);
            tVect3.z = sML.RoundToDecimalPlace(tVect3.z, 4);
            this.transform.localPosition = tVect3;
            tVect3 = this.transform.localEulerAngles;
            tVect3.x = (int)tVect3.x;// sML.RoundToDecimalPlace(tVect3.x, 1);
            tVect3.y = (int)tVect3.y;//sML.RoundToDecimalPlace(tVect3.y, 1);
            tVect3.z = (int)tVect3.z;//sML.RoundToDecimalPlace(tVect3.z, 1);
            this.transform.localEulerAngles = tVect3;
            //}
        }

        Scr_Socket_Male tSM = this.transform.root.GetComponentInChildren<Scr_Socket_Male>();
        if (tSM != null)
            vMaleSocket = tSM.transform;
        vParent = transform.parent;
        vLocalPosition = transform.localPosition;
        vEulerAngles = transform.localEulerAngles;
        /*
        if (vMaleSocket != this.transform)
        {
            this.transform.SetParent(vMaleSocket);
            vSocketPosition = transform.localPosition;
        }
        else
            vSocketPosition = Vector3.zero;
            */
        //ResetParent();
    }
    
    
    [ContextMenu("ResetParent")]
    public void ResetParent() // Reset to main parent
    {
        transform.SetParent(vParent);
        transform.localPosition = vLocalPosition;
        transform.localEulerAngles = vEulerAngles;
    }
    
    /*
    [ContextMenu("Realign Parent")]
    public void SetSocketParent(Transform tParent) // Reset to connect
    {
        transform.SetParent(tParent);
        transform.localPosition = vLocalPosition;
        transform.localEulerAngles = vEulerAngles;
    }
    */
}
