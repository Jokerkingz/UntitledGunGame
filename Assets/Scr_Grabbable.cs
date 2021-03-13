using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Grabbable : MonoBehaviour
{
    public Scr_Connect_System cCS;
    public Rigidbody cRB;
    public MeshCollider cMC;
    public Vector3 vPositionOffset;
    public Vector3 vAngleOffset;
    public Scr_Socket_System cSS;

    [Header("Hand setup")]
    public Vector3 vHandPositionOffset;
    public Vector3 vHandAngleOffset;

    public void Reset()
    {
        cCS = transform.parent.GetComponent<Scr_Connect_System>();

        if (cRB == null)
        {
            // If no rigidbody is on this object, check if any parent has one
            cRB = this.transform.root.GetComponentInChildren<Rigidbody>();
            // if there is still no rigidbody then be the rigidbody
            if (cRB == null)
                cRB = this.transform.root.gameObject.AddComponent<Rigidbody>();
        }

        cMC = this.GetComponent<MeshCollider>();

        if (cMC == null)
            cMC = this.gameObject.AddComponent<MeshCollider>();
        cMC.convex = true;

        cSS = this.GetComponent<Scr_Socket_System>();

        this.tag = "Grabbable";

    }
}
