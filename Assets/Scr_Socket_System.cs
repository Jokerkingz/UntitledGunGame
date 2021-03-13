using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Socket_System : MonoBehaviour
{
    public Scr_GameController gGC;
    public Scr_Grabbable vGrabbablePart;
    
    [System.Serializable]
    public class SocketTransform{
        Vector3 vec3Position = Vector3.zero;
        Vector3 vec3Rotation = Vector3.zero;
    }

    [Header("Socket System")]
    public Scr_Socket_Male cSM;
    public SocketTransform vMaleSocket;
    public SocketTransform[] vFemaleSockets;

    public Vector3 vSocketOffset;
    public Vector3 vHandOffset;

    public SocketTransform[] vConnections;
    public SocketTransform vConnectedSocket;

    public float vSearchTimer;
    // SocketAnimation
    //[Header("Socket Animation")]
    //public MeshRenderer vSocketMeshRender;
    //public Scr_Socket_Animated vTempAnimator;

    void Reset()
    {
        vGrabbablePart = this.GetComponent<Scr_Grabbable>();
        gGC = GameObject.FindGameObjectWithTag("GameController").GetComponent<Scr_GameController>();
        cSM = this.transform.root.GetComponentInChildren<Scr_Socket_Male>();
        this.enabled = false;
    }


    void Update()
    {
        if (vSearchTimer > 0f)
        {
            vSearchTimer -= Time.deltaTime;
        } else
        {
            TurnOff();
        }
        FindMate();
    }

    GameObject[] SearchSocket()
    {
        GameObject[] tTempList = GameObject.FindGameObjectsWithTag("Socket_Female");
        List<GameObject> tFiltered = new List<GameObject>();
        tFiltered.Clear();

        foreach (GameObject tTemp in tTempList)
        {
            if (tTemp.transform.root != this.transform.root)
            {
                if (!tTemp.GetComponent<Scr_Socket_Female>().vIsConnected)
                    tFiltered.Add(tTemp);
            }
        }


        GameObject[] vSockets = new GameObject[0];
        vSockets = tFiltered.ToArray();
        return vSockets;
    }

    GameObject GetClosestGameobject(GameObject[] tList, Vector3 tPoint)
    {
        GameObject tClosestObject = null;
        float tClosestDistance = 10f; // max
        float tDistanceCurrent = 10f; // 
        foreach (GameObject tObject in tList)
        {
            tDistanceCurrent = Vector3.Distance(tObject.transform.position, tPoint);
            if (tDistanceCurrent < tClosestDistance)
            {
                tClosestObject = tObject;
                //tDistanceCurrent = tClosestDistance;
                tClosestDistance = tDistanceCurrent;
            }
        }
        return tClosestObject;
    }

    void ConnectToFemale(GameObject tTarget)
    {
        //Debug.Log("Connected");
        //this.transform.parent = tTarget.transform;
        vGrabbablePart.cCS.ConnectToSocket(tTarget.transform);
        
        //this.transform.localEulerAngles = Vector3.zero;
        //this.transform.localPosition = Vector3.zero;

        vGrabbablePart.cRB.velocity = Vector3.zero;
        vGrabbablePart.cRB.angularVelocity = Vector3.zero;
        vGrabbablePart.cRB.isKinematic = true;
        vGrabbablePart.cRB.useGravity = false;
        
        TurnOff();
    }
    /*
    void Socket()
    {
        //Socket list of socket this part has already and must be refreshed per detachment and connection.

        //Filter
        // if NOT connected
        // if NOT same parent (if NOT the same root, then continue)

        Scr_Socket_Female[] tList = transform.root.GetComponentsInChildren<Scr_Socket_Female>();
    }
    */
    void FindMate()
    {
        //Debug.Log("Searching");
        GameObject tTarget = null;
        //GameObject[] tTargets = GameObject.FindGameObjectsWithTag("Socket_Female");
        GameObject[] tTargets = SearchSocket();
        tTarget = GetClosestGameobject(tTargets, this.transform.position);
        if (tTarget != null && Vector3.Distance(tTarget.transform.position,this.transform.position) < .2f)//.1f)
        {
            ConnectToFemale(tTarget);
            this.enabled = false;
        }
    }

    public void GrabFind(Vector3 tPosition)//, Scr_Socket_Male tMaleSocket)
    {
        //GameObject[] tTargets = GameObject.FindGameObjectsWithTag("Socket_Female");
        //tTarget = GetClosestGameobject(tTargets, tPosition);
        GameObject tTarget = null;
        GameObject[] tTargets = SearchSocket();
        tTarget = GetClosestGameobject(tTargets, tPosition);
        if (tTarget != null && Vector3.Distance(tTarget.transform.position, this.transform.position) < .2f)//.1f) 
        {
            // Start using single socket animation
            //GetAnimation();
            //Visualize(cSM, tTarget.transform);
            //this.enabled = false;
        }

    }
    public void TurnOn()
    {
        vSearchTimer = 3f;
        this.enabled = true;
    }

    void TurnOff()
    {
        vSearchTimer = 0f;
        this.enabled = false;
    }

    /*
    void GetAnimation()
    {
        // if No Single socket animation is used, request in global to get one
        if (!vTempAnimator)
        {
            vTempAnimator = gGC.RequestForObject(vTempAnimator, "Male");
            vTempAnimator.StartSocketAnimation(vSocketMeshRender, this);
        }
        else
            vTempAnimator.vWeight = 1f;

    }
    */
    /*
    void Visualize(Scr_Socket_Male tMale, Transform tFemale)
    {
        Debug.Log("Visualize Ping");
        // Get an animator
        if (!vTempAnimator)
        {
            vTempAnimator = gGC.RequestForObject();
        }
        vTempAnimator.StartAnimation(tMale, tFemale);
        vTempAnimator.vTempOwner = this;
        vTempAnimator.vMaleWeight = 1f;
        vTempAnimator.vFemaleWeight = 1f;
    }*/
}
