using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Socket_Animation : MonoBehaviour
{
    /*
    [Header("Misc")]
    public Scr_Socket_System vTempOwner;

    [Header("Male Socket")]
    public Transform vMaleAnchor;
    public Transform vMaleTransform;
    public Animator vMaleAniCon;
    public MeshRenderer vMaleRender;
    public SkinnedMeshRenderer vMaleSkin;
    public float vMaleWeight;


    [Header("Femalt Socket")]
    public Transform vFemaleAnchor;
    public Transform vFemaleTransform;
    public Animator vFemaleAniCon;
    public MeshRenderer vFemaleRender;
    public SkinnedMeshRenderer vFemaleSkin;
    public float vFemaleWeight;
    
    void Update()
    {
        if (!vMaleAnchor || vFemaleAnchor)
            TurnOff();
    }

    public void StartAnimation(Scr_Socket_Male vMale, Transform vFemale)
    {
        Debug.Log("Start Animation");
        // Initialize variables
        MeshRenderer tTemp;

        // Get the transforms to anchor to
        vMaleAnchor = vMale.transform;
        vFemaleAnchor = vFemale;

        // Render Stuff - Check if objects are missing if necessary
        vMaleSkin.enabled = true;
        vFemaleSkin.enabled = true;

        tTemp = vMale.GetComponent<MeshRenderer>();
        if (tTemp == null) // Catch error
        {
            Debug.Log("Missing Male Socket Render");
            return;
        } else
        {
            tTemp.enabled = false;
        }

        tTemp = vFemale.GetComponent<MeshRenderer>();
        if (tTemp == null) // Catch error
        {
            Debug.Log("Missing Female Socket Render");
            return;
        }
        else
        {
            tTemp.enabled = false;
        }

        // Start Animations
        vMaleAniCon.SetBool("IsActive", true); 
        vFemaleAniCon.SetBool("IsActive", true);

        // Parent Mesh (for simplicity sake rather than using update because update will lag behind when following objects on VR)
        vMaleTransform.SetParent(vMaleAnchor);
        vMaleTransform.localPosition = Vector3.zero;
        vMaleTransform.localEulerAngles = Vector3.zero;

        vFemaleTransform.SetParent(vFemaleAnchor);
        vFemaleTransform.localPosition = Vector3.zero;
        vFemaleTransform.localEulerAngles = Vector3.zero;

        // Turn on this script for passive actions
        this.enabled = true;
    }

    public void EndAnimation()
    {

    }

    public void TurnOff()
    {
        Debug.Log("Turned Off");
        // Remove Parenting
        vMaleTransform.SetParent(null);
        vFemaleTransform.SetParent(null);

        // Readjust rendering
        vMaleSkin.enabled = false;
        vFemaleSkin.enabled = false;

        if (vMaleAnchor) // Catch error
        {
            vMaleAnchor.GetComponent<MeshRenderer>().enabled = false;
        }

        if (vFemaleAnchor) // Catch error
        {
            vFemaleAnchor.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    */
}
