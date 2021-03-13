using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Mechanism_System : MonoBehaviour
{
    public Scr_Mechanism_Output[] MOutputs;
    public Scr_Mechanism_Input[] MInputs;
    public Scr_Mechanism_Modifiers[] MModifiers;
    public Scr_Mechanism_Special[] MSpecial;
    // Public Scr_Mechanism_Custom[] MCustom;

    public int vTotalAmmo;
    public float vTotalEnergy;
    public float vTotalFuel;

    public void Start()
    {
    }

    public void UpdateMechanism() // Mechanism MUST be updated this way. IF adding or removing when a part is detached, it DOESNT count the other parts connected to the connected/detached mouth
    {
        MOutputs = this.GetComponentsInChildren<Scr_Mechanism_Output>();
        MInputs = this.GetComponentsInChildren<Scr_Mechanism_Input>();
        MModifiers = this.GetComponentsInChildren<Scr_Mechanism_Modifiers>();
        MSpecial = this.GetComponentsInChildren<Scr_Mechanism_Special>();
    }

    public void SendTrigger(char tTruggerType)
    {
        foreach (Scr_Mechanism_Output tOut in MOutputs)
        {
            tOut.TriggerReceive('P', this);
        }
    }

    void GetTotalInput()
    {
        vTotalAmmo = 0;
        vTotalEnergy = 0;
        vTotalFuel = 0;
        foreach (Scr_Mechanism_Input tInput in MInputs)
        {
            vTotalAmmo += tInput.GetAmmo();
            vTotalEnergy += tInput.GetEnergy();
            //vTotalFuel += tInput.GetFuel();
        }
    }
    
    public GameObject RequestAmmo(bool tNeedsAmmo, float tEnergy, float tFuel)
    {
        // Ammo request MUST AND ONLY BE singular ammo because a single gameobject is given. MODIFIERS
        GameObject tObj = null;

        // Check if There is enough ammo in all input
        GetTotalInput();
        bool tPass = true;
        if (tNeedsAmmo && vTotalAmmo <= 0)
            tPass = false;
        if (vTotalEnergy < tEnergy)
            tPass = false;
        if (vTotalFuel < tFuel)
            tPass = false;

        if (!tPass)
        {
            // Click sound
            return null;
        }

        // if yes, take all ammo
        

        foreach (Scr_Mechanism_Input tInput in MInputs)
        {
            // if this input has enough ammo, use it.
            if (tNeedsAmmo && tObj == null)
            {
                tObj = tInput.TakeAmmo(1);
            }
            if (tEnergy > 0)
            {
                //tInput.TakeAmount(0, tEnergy, 0);
                tEnergy = tEnergy - tInput.GetEnergy();
                if (tEnergy < 0)
                    tEnergy = 0f;
            }
            
        }
        return tObj;
    }
}
