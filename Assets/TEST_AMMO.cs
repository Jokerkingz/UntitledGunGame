using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_AMMO : TEST_INPUT
{
    public int vAmmo;
    // Start is called before the first frame update
    public override void ReduceAmmo()
    {
        vAmmo--;
    }
    
}
