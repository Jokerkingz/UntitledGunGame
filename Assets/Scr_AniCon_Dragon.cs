using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_AniCon_Dragon : MonoBehaviour
{
    public Animator cAnimator;
    public int vBodyLeft;
    public int vBodyRight;
    public bool vTail;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cAnimator.SetInteger("Body_Left", vBodyLeft);
        cAnimator.SetInteger("Body_Right", vBodyRight);
        cAnimator.SetBool("Tail", vTail);
    }
}
