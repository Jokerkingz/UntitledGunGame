using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_AniScr_Tail : MonoBehaviour
{

    //public Transform vTailAnchor;
    public Vector3 vCurrent;

    public Transform[] aOriginal = new Transform[5];
    public Transform[] aTailList = new Transform[5];
    public Vector3[] aTailPositionList = new Vector3[5];
    public float vMaxTailDistance = 1.0f;

    public int vMaxToTest;
    public bool vShouldLookAtPrevious = false;
    public Vector3 vAngleOffset;
    // Start is called before the first frame update
    void Start()
    {


        vCurrent = transform.position;
        for (int i = 0; i < aTailPositionList.Length; i++)
        {
            aTailPositionList[i] = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        vCurrent = transform.position;
        UpdateTail(vCurrent);
        UpdatePosition(vCurrent);
    }

    void UpdateTail(Vector3 tSource)
    {
        //int tIndex = 0;
        Vector3 tVector3 = Vector3.zero;
        float tDistance = 0;
        float tMultiplier;
        Vector3 tCurrent = tSource;
        string tHasMoved = " Has Not Moved ";
        for (int i = 0; i < aTailPositionList.Length; i++)
        {
            tHasMoved = " Has Not Moved ";
            //aTailPositionList[0] = transform.position;
            tDistance = Vector3.Distance(aTailPositionList[i], tCurrent);
            if (tDistance > vMaxTailDistance)
            {
                //tMultiplier = vMaxTailDistance - (vMaxTailDistance / tDistance);
                //tMultiplier = (1f - (vMaxTailDistance / tDistance));
                tMultiplier = ((tDistance-vMaxTailDistance) / tDistance);
                tVector3.x = (tCurrent.x - aTailPositionList[i].x);// * tMultiplier;
                tVector3.y = (tCurrent.y - aTailPositionList[i].y);// * tMultiplier;
                tVector3.z = (tCurrent.z - aTailPositionList[i].z);// * tMultiplier;
                //tVector3 = tVector3.normalized;// * tMultiplier;// * vMaxTailDistance;
                aTailPositionList[i] += tVector3 * tMultiplier;
                tHasMoved = " Has Moved " + (tMultiplier* tDistance).ToString();
            }
            tCurrent = aTailPositionList[i];
        }
    }

    void UpdatePosition(Vector3 tCurrent)
    {

        for (int i = 0; i < aTailList.Length; i++)
        {
            aTailList[i].transform.position = aTailPositionList[i];
            if (i < aTailList.Length-1 && vShouldLookAtPrevious)
            { 
                aTailList[i].transform.LookAt(aTailList[i+1]);
                aTailList[i].localEulerAngles = aTailList[i].localEulerAngles;
            }
            //tCurrent = aTailList[i].transform.position;
        }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < aOriginal.Length; i++)
        {
            // Working Version
            /*
            if (i == 0)
            {
                Vector3 tVectA = vAngleOffset;
                tVectA.x += 180f;
                aOriginal[i].eulerAngles = aTailList[i].eulerAngles + tVectA;
            }
            else*/
            aOriginal[i].eulerAngles = aTailList[i].eulerAngles + vAngleOffset;

            //Test Version 
            /*
            tVectA.x = aOriginal[i].eulerAngles.x - (aTailList[i].eulerAngles.x + vAngleOffset.x);
            tVectA.y = (aTailList[i].eulerAngles.y + vAngleOffset.y) - aOriginal[i].eulerAngles.y;
            tVectA.z = aOriginal[i].eulerAngles.z - (aTailList[i].eulerAngles.z + vAngleOffset.z);

            aOriginal[i].eulerAngles = aOriginal[i].eulerAngles + (tVectA * .5f);
            */
        }
    }
}
