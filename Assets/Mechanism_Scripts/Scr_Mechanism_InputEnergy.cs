using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Mechanism_InputEnergy : Scr_Mechanism_Input
{
    public float vMaxEnergy;
    public float vEnergy;
    public float vRegenerate;


    public void Update()
    {
        if (vRegenerate != 0)
        {
            vEnergy += vRegenerate;
            vEnergy = Mathf.Clamp(vEnergy, 0f, vMaxEnergy);
        }
    }

    public override float GetEnergy()
    {
        return vEnergy;
    }

    public override float TakeEnergy(float tAmount)
    {
        return (tAmount - vEnergy);
    }
}
