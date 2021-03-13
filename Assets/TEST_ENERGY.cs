using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ENERGY : TEST_INPUT
{
    public float vEnergy;
    public override void ReduceEnergy()
    {
        vEnergy -= 5f;
    }
    public override float GetEnergy()
    {
        return vEnergy;
    }
}

