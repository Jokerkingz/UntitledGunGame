using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Hand_System : MonoBehaviour
{
    public string vState;
    public Scr_Animator_Hand cAH;
    public float vSpin;

    public Scr_GrabSystem cGS;

    // Animation System if the variable only affects animation, DO NOT PUT IT HERE
    // Added here to shrink data passing
    public float vLerpRate = 5f;

    public float vThumbLerp = 0f;
    public bool vThumbState;
    public bool vThumbA;
    public bool vThumbB;
    public bool vThumbC;
    public bool vThumbD;

    public float    vIndLerp = 0f;
    public bool     vIndTouch;
    public float    vIndPress;
    public bool     vMidTouch;
    public float    vMidPress;

    public Vector2 vAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGrabSystem();
        UpdateAnimation();
    }

    //public void 



    public void NextState()
    {
        Debug.Log("Next State Called");
        switch (vState)
        {
            default:
                vState = "Open";
                cAH.ResetBools();
                break;

            case "Hand":
                vState = "Open";
                cAH.ResetBools();
                break;

            case "Open":
                vState = "Close";
                cAH.ResetBools();
                cAH.vIsClosed = true;
                break;

            case "Close":
                vState = "Inner";
                cAH.ResetBools();
                cAH.vIsInner = true;
                break;

            case "Inner":
                vState = "Key";
                cAH.ResetBools();
                cAH.vIsKey = true;
                break;

            case "Key":
                vState = "Hand";
                cAH.ResetBools();
                cAH.vIsHand = true;
                break;

        }
    }


    public void UpdateGrabSystem()
    {
        
    }

    void UpdateAnimation()
    {
        switch (vState)
        {
            default:
                if (cAH.vWeight > 0f)
                    cAH.vWeight -= vLerpRate * Time.deltaTime;
                cAH.vWeight = Mathf.Clamp(cAH.vWeight, 0f, 1f);

                float tSpeed = vAxis.magnitude;
                if (tSpeed > .1f)
                {
                    cAH.vIsSpin = true;
                    cAH.vSpinWeight = tSpeed;
                }
                else
                    cAH.vIsSpin = false;
                break;
            case "Hand":

                // Animation Setting
                if (cAH.vWeight < 1f)
                    cAH.vWeight += vLerpRate * Time.deltaTime;
                cAH.vWeight = Mathf.Clamp(cAH.vWeight, 0f, 1f);
                bool tBoolThumb = false;
                //bool tBoolIndex = false;
                float tIndLerp = 0f;
                float tMidLerp = 0f;
                if (vThumbA || vThumbB || vThumbC || vThumbD)
                {
                    tBoolThumb = true;
                }

                // Thumb
                if (tBoolThumb)
                    vThumbLerp += vLerpRate * Time.deltaTime;
                else
                    vThumbLerp -= vLerpRate * Time.deltaTime;
                vThumbLerp = Mathf.Clamp(vThumbLerp, 0f, 1f);
                cAH.vLerpTmb = vThumbLerp;

                // Index
                if (vIndTouch)
                    vIndLerp += vLerpRate * Time.deltaTime;
                else
                    vIndLerp -= vLerpRate * Time.deltaTime;
                vIndLerp = Mathf.Clamp(vIndLerp, 0f, .4f);
                tIndLerp = vIndLerp + (vIndPress * .6f);
                cAH.vLerpInd = tIndLerp;

                // Middle
                tMidLerp += vMidPress;
                cAH.vLerpMid = tMidLerp;
                break;
        }
    }
}
