using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class TEST_SCRIPT : MonoBehaviour
{
    public bool StartTest;
    public TEST_INPUT vTheAMMO; // if this work, then awesome
    public TEST_ENERGY vTheEnergy;
    public TEST_INPUT[] vInputList;

    public float vTotalEnergy;
    private void Update()
    {
        if (StartTest)
        {
            vTotalEnergy = 0;
            vTheAMMO.ReduceAmmo();
            vTheEnergy.ReduceEnergy();
            vInputList = this.GetComponents<TEST_INPUT>();
            foreach (TEST_INPUT tInput in vInputList)
            {
                tInput.ReduceEnergy();
                vTotalEnergy += tInput.GetEnergy();
            }
            StartTest = false;
        }
    }
}
