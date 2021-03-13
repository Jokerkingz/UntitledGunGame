using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Socket_Animated : MonoBehaviour
{
    /*
    public bool vIsBeingUsed;
    public float vWeight;
    public bool vIsActive;
    public Animator vAniCon;
    public Scr_Socket_System cSSSource;
    public MeshRenderer vSource;
    public SkinnedMeshRenderer vOwnRender;

    void Reset()
    {
        vAniCon = this.GetComponent<Animator>();
        vOwnRender = GetComponentInChildren<SkinnedMeshRenderer>();
    }
    public void StartSocketAnimation(MeshRenderer tSource, Scr_Socket_System tSS)
    {
        this.enabled = true;
        vIsBeingUsed = true;
        vOwnRender = GetComponentInChildren<SkinnedMeshRenderer>();
        vWeight = 1f;
        vSource = tSource;
        vSource.enabled = false;
        vOwnRender.enabled = true;
        this.transform.SetParent(tSource.transform);
        transform.localEulerAngles = tSource.transform.localEulerAngles;
        transform.localPosition = Vector3.zero;
        cSSSource = tSS;
    }
    void Update()
    {
        if (vWeight > 0)
        {
            vWeight -= Time.deltaTime;
            if (vWeight < 0)
            {
                EndSocketAnimation();
            }
        }
        vAniCon.SetFloat("IsActive", vWeight);
    }
    
    void EndSocketAnimation()
    {
        this.transform.SetParent(null);
        vAniCon.Play(0, 0, 0); // Reset animation
        vIsBeingUsed = false;
        vSource.enabled = true;
        vWeight = 0f;
        vOwnRender.enabled = false;
        cSSSource.vTempAnimator = null;
        this.enabled = false;
    }
    */



}
