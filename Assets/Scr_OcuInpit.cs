using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Scr_OcuInpit : MonoBehaviour
{
    // Scr_OcuInpit -> Scr_InputToAction -> Scr_Scr_Animator_Hands | Scr_Hand_Use
    [Header("Setup System")]
    public bool vIsUsingLeft;
    public Scr_Animator_Hand cAniHnd;
    public Scr_InputToAction cITA;
    public string vInputHardware;

    [Header("SteamVR Set")]
    #region SteamVRInput
    // Hand Source set to selected hand pllez
    public SteamVR_Input_Sources vHandType;

    // Left
    public SteamVR_Action_Boolean   vLIndexClick;       // Click - Click moment when a button is pressed at full
    public SteamVR_Action_Boolean   vLIndexRest;        // Rest - when the sensor sees the finger on the button but not pressing it
    public SteamVR_Action_Single    vLIndexPress;       // Press - float 0-1 depression value from fully unpressed to fully pressed
    public SteamVR_Action_Boolean   vLMiddleClick;
    public SteamVR_Action_Boolean   vLMiddleRest;
    public SteamVR_Action_Single    vLMiddlePress;
    public SteamVR_Action_Boolean   vLThumbX;
    public SteamVR_Action_Boolean   vLThumbXRest;
    public SteamVR_Action_Boolean   vLThumbY;
    public SteamVR_Action_Boolean   vLThumbYRest;
    public SteamVR_Action_Boolean   vLThumbMenu;
    public SteamVR_Action_Boolean   vLThumbMenuRest;
    public SteamVR_Action_Vector2   vLThumbAnal;        // Analog - XY axis
    public SteamVR_Action_Boolean   vLThumbAnalRest;    // Rest - if thumb is on analog
    public SteamVR_Action_Boolean   vLThumbAnalClick;   // When Button be pressed

    //Right
    public SteamVR_Action_Boolean   vRIndexClick;       // Click - Click moment when a button is pressed at full
    public SteamVR_Action_Boolean   vRIndexRest;        // Rest - when the sensor sees the finger on the button but not pressing it
    public SteamVR_Action_Single    vRIndexPress;       // Press - float 0-1 depression value from fully unpressed to fully pressed
    public SteamVR_Action_Boolean   vRMiddleClick;
    public SteamVR_Action_Boolean   vRMiddleRest;
    public SteamVR_Action_Single    vRMiddlePress;
    public SteamVR_Action_Boolean   vRThumbA;
    public SteamVR_Action_Boolean   vRThumbARest;
    public SteamVR_Action_Boolean   vRThumbB;
    public SteamVR_Action_Boolean   vRThumbBRest;
    public SteamVR_Action_Vector2   vRThumbAnal;        // Analog - XY axis
    public SteamVR_Action_Boolean   vRThumbAnalRest;    // Rest - if thumb is on analog
    public SteamVR_Action_Boolean   vRThumbAnalClick;   // When Button be pressed

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        switch (vInputHardware) {

            default:    // Occulus Touch
                if (vIsUsingLeft) 
                {
                    vLIndexClick.AddOnStateDownListener(IndexClicked, vHandType);
                    vLIndexRest.AddOnUpdateListener(IndexRestUpdate,vHandType);
                    vLIndexPress.AddOnUpdateListener(IndexPressUpdate, vHandType);
                    vLMiddleClick.AddOnStateDownListener(MiddleClicked, vHandType);
                    vLMiddleRest.AddOnUpdateListener(MiddleRestUpdate, vHandType);
                    vLMiddlePress.AddOnUpdateListener(MiddlePressUpdate, vHandType);
                    vLThumbX.AddOnStateDownListener(XAClicked, vHandType);
                    vLThumbXRest.AddOnUpdateListener(XARestUpdate, vHandType);
                    vLThumbY.AddOnStateDownListener(YBClicked, vHandType);
                    vLThumbYRest.AddOnUpdateListener(YBRestUpdate, vHandType);
                    vLThumbMenu.AddOnStateDownListener(MenuClicked, vHandType);
                    vLThumbMenuRest.AddOnUpdateListener(MenuRestUpdate, vHandType);
                    vLThumbAnal.AddOnUpdateListener(AnalAxis, vHandType);
                    vLThumbAnalRest.AddOnUpdateListener(AnalRestUpdate, vHandType);
                    vLThumbAnalClick.AddOnStateDownListener(AnalClicked, vHandType);
                } else
                {
                    vRIndexClick.AddOnStateDownListener(IndexClicked, vHandType);
                    vRIndexRest.AddOnUpdateListener(IndexRestUpdate, vHandType);
                    vRIndexPress.AddOnUpdateListener(IndexPressUpdate, vHandType);
                    vRMiddleClick.AddOnStateDownListener(MiddleClicked, vHandType);
                    vRMiddleRest.AddOnUpdateListener(MiddleRestUpdate, vHandType);
                    vRMiddlePress.AddOnUpdateListener(MiddlePressUpdate, vHandType);
                    vRThumbA.AddOnStateDownListener(XAClicked, vHandType);
                    vRThumbARest.AddOnUpdateListener(XARestUpdate, vHandType);
                    vRThumbB.AddOnStateDownListener(YBClicked, vHandType);
                    vRThumbBRest.AddOnUpdateListener(YBRestUpdate, vHandType);
                    vRThumbAnal.AddOnUpdateListener(AnalAxis, vHandType);
                    vRThumbAnalRest.AddOnUpdateListener(AnalRestUpdate, vHandType);
                    vRThumbAnalClick.AddOnStateDownListener(AnalClicked, vHandType);
                }

                break;
        }

        // Set Buttons to funciton
        //vIndexTouch.AddOnUpdateListener(IndexTest, vHandType);
        //vThumbB.AddOnChangeListener(InputThumbChange, vHandType);
        //vIndexTouch.AddOnUpdateListener(IndexAEWDfTest, vHandType);
    }

    public void IndexClicked(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        cITA.IndexClick();
    }
    public void IndexRestUpdate(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool tCurrentBool)
    {
        cITA.IndexRestUpdate(tCurrentBool);
    }
    public void IndexPressUpdate(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float tCurrent, float tDelta)
    {
        cITA.IndexPressUpdate(tCurrent);
    }
    public void MiddleClicked(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        cITA.MiddleClicked();
    }
    public void MiddleRestUpdate(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool tCurrentBool)
    {
        cITA.MiddleRestUpdate(tCurrentBool);
    }
    public void MiddlePressUpdate(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float tCurrent, float tDelta)
    {
        cITA.MiddlePressUpdate(tCurrent);
    }
    public void XAClicked(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        cITA.XAClicked();
    }
    public void XARestUpdate(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool tCurrentBool)
    {
        cITA.XARestUpdate(tCurrentBool);
        
    }
    public void YBClicked(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        cITA.YBClicked();
    }
    public void YBRestUpdate(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool tCurrentBool)
    {
        cITA.YBRestUpdate(tCurrentBool);
    }
    public void MenuClicked(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        cITA.MenuClicked();
    }
    public void MenuRestUpdate(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool tCurrentBool)
    {
        cITA.MenuRestUpdate(tCurrentBool);
    }
    public void AnalAxis(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 tAxis, Vector2 tDelta)
    {
        cITA.AnalAxis(tAxis);
    }
    public void AnalClicked(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        cITA.AnalClicked();
    }
    public void AnalRestUpdate(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool tCurrentBool)
    {
        cITA.AnalRestUpdate(tCurrentBool);
    }
}
