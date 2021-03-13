using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Animator_Hand : MonoBehaviour
{
    // Scr_OcuInpit -> Scr_InputToAction -> Scr_Scr_Animator_Hands | Scr_Hand_Use
    public Animator cAni;
    public string vHandState;


    public bool vIsHand;
    public bool vIsSpin;
    public bool vIsClosed;
    public bool vIsInner;
    public bool vIsKey;
    
    public float vWeightThm;
    public float vWeightInd;
    public float vWeightMid;
    public float vWeightRng;
    public float vWeightPnk;

    public float vWeight;
    public float vLerpTmb;
    public float vLerpInd;
    public float vLerpMid;

    public float vSpinWeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tick();
        //cAni["HandToClose"].time = vLerpThumb;
        cAni.Play("HandToClose", 1, vLerpTmb);
    }

    public void Tick()
    {
        StateManager();
        UpdateFinger();
        UpdateSpin();
    }

    public void ResetBools()
    {
        vIsClosed = false;
        vIsHand = false;
        vIsInner = false;
        vIsKey = false;
        vIsSpin = false;
    }

    void StateManager()
    {
        cAni.SetBool("IsHand", vIsHand);
        cAni.SetBool("IsSpin", vIsSpin);
        cAni.SetBool("IsInner", vIsInner);
        cAni.SetBool("IsClosed", vIsClosed);
        cAni.SetBool("IsKey", vIsKey);
    }

    public void UpdateFinger()
    {
        cAni.Play("HandToClose", 1, vLerpTmb);
        cAni.Play("HandToClose", 2, vLerpInd);
        cAni.Play("HandToClose", 3, vLerpMid);
        cAni.Play("HandToClose", 4, vLerpMid);
        cAni.Play("HandToClose", 5, vLerpMid);
        cAni.SetLayerWeight(0, 1f-vWeight);
        cAni.SetLayerWeight(1, vWeight);
        cAni.SetLayerWeight(2, vWeight);
        cAni.SetLayerWeight(3, vWeight);
        cAni.SetLayerWeight(4, vWeight);
        cAni.SetLayerWeight(5, vWeight);
    }

    void UpdateSpin()
    {
        if (vIsSpin)
        cAni.speed = vSpinWeight;
        else
            cAni.speed = .5f;
    }

    void UpdateMiddle(float tFloat)
    {
        vWeightMid = tFloat;
        vWeightRng = tFloat;
        vWeightPnk = tFloat;

    }
}
