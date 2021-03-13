using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Mechanism_InputAmmo : Scr_Mechanism_Input
{
    public GameObject vProjectile;
    public int vMaxAmmo;
    public int vAmmo;
    public bool vPop;

    public override GameObject GetObject()
    {
        return vProjectile;
    }

    public override int GetAmmo()
    {
        return vAmmo;
    }

    public override GameObject TakeAmmo(int tAmount)
    {
        vAmmo -= tAmount;
        return vProjectile;
    }
    
}
