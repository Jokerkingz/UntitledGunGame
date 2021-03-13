using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Mechanism_Parent : MonoBehaviour
{
    // Ammo
    public virtual GameObject GetObject(){return null;}
    public virtual int GetAmmo(){return 0;}
    public virtual GameObject TakeAmmo(int tAmount){return null;}

    // Energy
    public virtual float GetEnergy(){return 0f;}
    public virtual float TakeEnergy(float tAmount){ return tAmount; }

    // Fuel

    // Matter
}
