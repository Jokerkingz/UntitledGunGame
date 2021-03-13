using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GameController : MonoBehaviour
{


    [Header("Asset Source List")]
    public Material vMainMaterial;
    public Mesh vSocketFemale;
    public Mesh vSocketFemaleAnimated;

    public List<Scr_Socket_Animated> lSocketAnimationObjects;

    [Header("Animation Source")]
    public GameObject vPrefabMaleAnimation;
    public GameObject vPrefabFemaleAnimation;
    // Start is called before the first frame update
    void Start()
    {
        lSocketAnimationObjects = new List<Scr_Socket_Animated>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    // Request for animated sockets
    public Scr_Socket_Animated RequestForObject(Scr_Socket_Animated tTemp, string tType)
    {
        Scr_Socket_Animated tResult = null;

        // Choose which prefab to use
        GameObject tChosenPrefab;
        switch (tType)
        {
            case "Male":
                tChosenPrefab = vPrefabMaleAnimation;
                break;
            case "Female":
                tChosenPrefab = vPrefabFemaleAnimation;
                break;
            default:
                Debug.Log("Error Request in Scr_Socket_Animated for " + tType);
                return null;
        }

        // Search for available Slot in List
        foreach (Scr_Socket_Animated tSokAni in lSocketAnimationObjects)
        {
            if (tSokAni.enabled == false)
            {
                tResult = tSokAni;
                break;
            }
        }

        // No object found, create a new one
        if (!tResult)
        {
            GameObject tObj = Instantiate(tChosenPrefab);
            tResult = tObj.GetComponent<Scr_Socket_Animated>();
            lSocketAnimationObjects.Add(tResult);
        }

        return tResult;
    }
    

    public GameObject RequestForObject(GameObject tTemp)
    {
        GameObject tResult = null;

        /* Test case if a
        // Search for available Game object
        foreach (Scr_Socket_Animated tSokAni in lSocketAnimationObjects)
        {
            if (tSokAni.enabled == false)
            {
                tResult = tSokAni;
                break;
            }
        }

        // No object found, create a new one
        if (!tResult)
        {
            GameObject tObj = Instantiate(vPrefabMaleAnimation);
            tResult = tObj.GetComponent<Scr_Socket_Animated>();
            lSocketAnimationObjects.Add(tResult);
        }
        */
        return tResult;
    }
}
