using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Part_System : MonoBehaviour
{
    public Scr_Connect_System cCS;
    public Rigidbody cRB;
    public MeshCollider cMC;
    public Vector3 vPositionOffset;
    public Vector3 vAngleOffset;
    public Scr_Socket_System cSS;

    void Reset()
    {
        cCS = transform.parent.GetComponent<Scr_Connect_System>();
        
        if (cRB == null)
            cRB = this.transform.root.gameObject.AddComponent<Rigidbody>();

        cMC = this.GetComponent<MeshCollider>();

        if (cMC == null)
            cMC = this.gameObject.AddComponent<MeshCollider>();
        cMC.convex = true;
        
        cSS = this.GetComponent<Scr_Socket_System>();

        this.tag = "Grabbable";

    }
    
}
