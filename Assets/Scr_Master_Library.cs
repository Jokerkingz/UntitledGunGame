using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Master_Library : MonoBehaviour
{

    /*
     * Notes for future expirments
     * 
     * Variable naming: Use a letter to identify the variable type for example
     *      v - variable - Used within the script -> vIndex
     *      t - temporary - Used within a function/method -> tIndex
     *      e - enum - enum eName{NameA,NameB,NameC}
     *      l - list - list<GameObject> = new list <GameObject>();
     *      a - array 
     *      s - Script - sAction = GetComponent<Scr_Action>();
     *      c - component - similar to s but for non script components - cRB = GetComponent<RigidBody>();
     * 
     * Asset Naming: have 3-4 letters do Indentify asset files then add underscore;
     *      spr_ - Sprites
     *      mat_ - Materials
     *      pre_ - Prefabs
     *      obj_ - Gameobjects
     *      sfx_ - Sound effects
     *      sce_ - Scene
     *      txtr_ - Texture
     *      
     *      
     * Categorizing: Always Categorize 
     * 
     * Spine extra animations: De not add extra animations that react to the environment 
     *      unless they are exact interaction like eyes looking on to an object or hands holding on to an object
     *      
     *
     */



    // This is a library of functions commonly used so that I don't have to keep typing the same thing over and over again
    // Most are basic calculation that can be found on the intermanet


    // Get if int is odd or even 
    public static bool IntIsEven(int tInt)
    {
        if (tInt % 2 == 0)
            return true;
        else
            return false;
    }


    // Get Vect2 positions from angle and distance
    public static Vector2 AngleDistanceToVect2(float tAngle, float tDistance)
    {
        Vector2 tResult = Vector2.zero;
        float tPi = Mathf.PI * tAngle / 180f;
        tResult.x = tDistance * Mathf.Cos(tPi);
        tResult.y = tDistance * Mathf.Sin(tPi);
        return tResult;
    }

    // Get Vect3 positions from angle and distance with Z locked to a certain nunmber
    public static Vector3 AngleDistanceToVect3(float tAngle, float tDistance, float tDefaultZ)
    {
        Vector3 tResult = Vector2.zero;
        float tPi = Mathf.PI * tAngle / 180f;
        tResult.x = tDistance * Mathf.Cos(tPi);
        tResult.y = tDistance * Mathf.Sin(tPi);
        tResult.z = tDefaultZ;
        return tResult;
    }

    // Get angles knowing that your postion is 0,0
    public static float XYToAngle(float tX, float tY)
    {
        float tRad = Mathf.Atan2(tY, tX);
        return tRad * (180 / Mathf.PI);
    }

    public static float GetAngleOf2Vector2(Vector2 tFrom, Vector2 tTo)
    {
        Vector2 tDifference = tTo - tFrom;
        float tRad = Mathf.Atan2(tDifference.x, tDifference.y);
        return tRad * (180 / Mathf.PI);
    }

    // Get Distance just between X and X or Y and Y
    public static float DistanceXToX(float tX1, float tX2)
    {
        float tResult = tX1 - tX2;
        tResult *= Mathf.Sign(tResult);
        return tResult;
    }

    public static float RoundToDecimalPlace(float tNumber, int tDecimalPlaces)
    {
        float tPowered = Mathf.Pow(10f, tDecimalPlaces);
        float tDecimal = Mathf.Pow(.1f, tDecimalPlaces);
        tNumber = (Mathf.Round(tNumber * tPowered) * tDecimal);
        //Debug.Log("Powered to " + tPowered.ToString() + " tDecimal " + tDecimal.ToString() + " Answer " + tNumber.ToString());
        return tNumber;
    }

    public static float OPL(float tCurrent, float tDestination, float tPercentage)
    {
        float tResult = 0f;
        //if (tCurrent != tDestination)
        //{
        float tDifference = tDestination - tCurrent;
        tResult = tDifference * tPercentage;
        //tCurrent = RoundToDecimalPlace(tCurrent, 3);
        //}
        return tResult;

        /* Example
        // Set the amount of change wanted
        vCurrentMouseScale += sML.OPL(vCurrentMouseScale, vPreferedMouseScale, 5f * Time.deltaTime);
        // Set decimal place to reduce float
        vCurrentMouseScale = sML.RoundToDecimalPlace(vCurrentMouseScale, 3);


        */
    }


    public static Vector3 OPL(Vector3 tCurrent, Vector3 tDestination, float tPercentage)
    {
        // Force to new postion not like float OPL

        Vector3 tResult = Vector3.zero;

        float tDifference = tDestination.x - tCurrent.x;
        tResult.x = tDifference * tPercentage;
        tDifference = tDestination.y - tCurrent.y;
        tResult.y = tDifference * tPercentage;
        tDifference = tDestination.z - tCurrent.z;
        tResult.z = tDifference * tPercentage;
        return tResult;

        /* Example
        // Set the amount to change
        Vector3 tSetPosition = vSpriteJournal.transform.position;
        if (vIsJournalActive)
        tSetPosition += sML.OPL(tSetPosition, vOnVectorGoal, 5f * Time.deltaTime);
        else 
        tSetPosition += sML.OPL(tSetPosition, vOffVectorGoal, 5f * Time.deltaTime);
        // Set decimal place to reduce float
        tSetPosition.x = sML.RoundToDecimalPlace(tSetPosition.x, 3);
        tSetPosition.y = sML.RoundToDecimalPlace(tSetPosition.y, 3);
        tSetPosition.z = sML.RoundToDecimalPlace(tSetPosition.z, 3);
        // Set to transform
        vJournal.transform.position = tSetPosition;
        */
    }

    /*
     *  Saved reference I turned angles and distance to a polygon collider
     *  
     *  
    public void CreateCollider(Vector2 tFrom, Vector2 tTo, float tScale,GameObject tOwner)
    {
        // Null Catcher
        if (tOwner == null)
            tOwner = this.gameObject;
        // Step One: Get Angles
        Vector2 tDifference;
        tDifference.x = tTo.x - tFrom.x;
        tDifference.y = tFrom.y - tTo.y;
        float tAngle = sML.XYToAngle(tDifference.x,tDifference.y);
        // Some how does not do it right
        //float tAngle = sML.GetAngleOf2Vector2(tFrom, tTo);

        //Vector2 tDifference = tTo - tFrom;
        // Step Two: Create Collider
        PolygonCollider2D tPolyCollider = tOwner.AddComponent<PolygonCollider2D>();
        // Step Three: Identify all required positions
        Debug.Log("Angle is " + tAngle.ToString() + " From " + tFrom.ToString() + " To " + tTo.ToString());
        Debug.Log("Angle is " + tAngle.ToString() + " Answer to angle " + sML.AngleDistanceToVect2(tAngle, 1).ToString());

        Vector2[] tPositions = new Vector2[4];
        tPositions[0] = sML.AngleDistanceToVect2(-tAngle - 90, tScale) + tFrom;
        tPositions[1] = sML.AngleDistanceToVect2(-tAngle - 90, tScale) + tTo;
        tPositions[2] = sML.AngleDistanceToVect2(-tAngle + 90, tScale) + tTo;
        tPositions[3] = sML.AngleDistanceToVect2(-tAngle + 90, tScale) + tFrom;

        tPolyCollider.SetPath(0, tPositions);
    }
    
    */
}
