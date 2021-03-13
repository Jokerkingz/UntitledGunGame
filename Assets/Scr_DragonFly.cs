using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_DragonFly : MonoBehaviour
{
    public Rigidbody cRB;



    [Header("Animation")]
    public Animator cAni;
    public int vHorizontal;
    public int vVertical;
    public int vLeftWing;
    public int vRightWing;
    public bool vTail;

    public Vector3 vOffset;
    public Transform vTail0;
    

    private void Reset()
    {
        cRB = GetComponent<Rigidbody>();
        cAni = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vHorizontal = 0;
        vVertical = 0;
        vLeftWing = 0;
        vRightWing = 0;
        vTail = false;
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Ping");
            cRB.AddForce(transform.forward * -.5f);
            vLeftWing++;
            vRightWing++;
            vTail = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Ping");
            cRB.rotation = Quaternion.Euler(transform.eulerAngles + (Vector3.down*1.0f));
            vHorizontal = -1;
            vLeftWing --;
            vRightWing ++;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Ping");
            cRB.rotation = Quaternion.Euler(transform.eulerAngles + (Vector3.up * 1.0f));
            vHorizontal = 1;
            vLeftWing ++;
            vRightWing --;
            //cRB.rotation = Quaternion.Euler(Vector3.up * 50.0f);
        }

        if (cRB.velocity.magnitude > 1f)
        {
            cRB.velocity = cRB.velocity.normalized;
        }

        AnimationUpdate();
    }
    private void LateUpdate()
    {
        //vTail0.localEulerAngles = vTail0.localEulerAngles + vOffset;
    }
    private void AnimationUpdate()
    {
        cAni.SetInteger("Horizon", vHorizontal);
        cAni.SetInteger("Vertic", vVertical);
        cAni.SetInteger("LeftWing", vLeftWing);
        cAni.SetInteger("RightWing", vRightWing);
        cAni.SetBool("Tail", vTail);
    }
}
