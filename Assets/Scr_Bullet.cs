using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Scr_Bullet : MonoBehaviour
{
    public Vector3 vPreviousPosition;
    public GameObject tObj;
    public LayerMask vLayerMask;
    // Start is called before the first frame update
    public void Start()
    {
        vPreviousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollision();
    }

    void CheckCollision()
    {
        Ray tRay = new Ray(vPreviousPosition, transform.position - vPreviousPosition);
        float tDistancce = Vector3.Distance(vPreviousPosition, transform.position);
        RaycastHit tHit;
        GameObject tObject;
        Debug.DrawRay(vPreviousPosition, transform.position - vPreviousPosition, Color.red);
        if (Physics.Raycast(vPreviousPosition, (transform.position - vPreviousPosition), out tHit, tDistancce, vLayerMask))
        {
            //this.transform.position = tHit.point;
            tObject = Instantiate(tObj, tHit.point, new Quaternion());
        }
        vPreviousPosition = transform.position;
    }
}
