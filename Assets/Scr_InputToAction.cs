using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_InputToAction : MonoBehaviour
{
    // Scr_OcuInpit -> Scr_InputToAction -> Scr_Scr_Animator_Hands | Scr_Hand_Use

    public Scr_Hand_System cHS;
    public Scr_GrabSystem cGS;


    public void IndexClick()
    {
        Debug.Log("IndexClick");
    }
    public void IndexRestUpdate(bool tBool)
    {
        cHS.vIndTouch = tBool;
        //Debug.Log("IndexRestUpdate");
    }
    public void IndexPressUpdate(float tFloat)
    {
        cHS.vIndPress = tFloat;
        //Debug.Log("IndexPressUpdate");
    }
    public void MiddleClicked()
    {
        Debug.Log("MiddleClicked");
    }
    public void MiddleRestUpdate(bool tBool)
    {
        cHS.vMidTouch = tBool;
        //Debug.Log("MiddleRestUpdate");

    }
    public void MiddlePressUpdate(float tFloat)
    {
        cGS.vPressValue = tFloat;
        cHS.vMidPress = tFloat;
    }
    public void XAClicked()
    {
        Debug.Log("XAClicked");
        cHS.NextState();
    }
    public void XARestUpdate(bool tBool)
    {
        cHS.vThumbA = tBool;
        //Debug.Log("XARestUpdate");
    }
    public void YBClicked()
    {
        Debug.Log("YBClicked");
    }
    public void YBRestUpdate(bool tBool)
    {
        cHS.vThumbB = tBool;
        //Debug.Log("YBRestUpdate");
    }
    public void MenuClicked()
    {
        Debug.Log("MenuClicked");
    }
    public void MenuRestUpdate(bool tBool)
    {
        cHS.vThumbC = tBool;
        //Debug.Log("MenuRestUpdate");
    }
    public void AnalAxis(Vector2 tVect2)
    {

        cHS.vAxis = tVect2;
        //Debug.Log("AnalAxis");
    }
    public void AnalClicked()
    {
        Debug.Log("AnalClicked");
    }
    public void AnalRestUpdate(bool tBool)
    {
        cHS.vThumbD = tBool;
        //Debug.Log("AnalRestUpdate");
    }
}
