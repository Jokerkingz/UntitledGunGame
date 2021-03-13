using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Mechanism_Output : MonoBehaviour
{
    [Header("Setup")]
    public Scr_GameController cGC;

    [Header("Input Type")]
    public bool vPrimaryInput;
    public bool vSecondaryInput;
    public bool vTertiaryInput;

    [Header("Output Setup")]
    public float vCoolDown;
    public Transform vOutputTransform;

    [Header("Unique Output information")]
    public string vName;
    public string vType; // Shoots ammo, Uses energy, 
    public float vSpeed;
    public GameObject vProjectile;
    public int vAmmoRequirement;
    public float vEnergyRequirement;
    public float vFuelRequirement;


    public void TriggerReceive(char tTriggerType, Scr_Mechanism_System tSource)
    {
        if (!this.enabled)
        {
            switch (tTriggerType)
            {
                default:
                    if (vPrimaryInput)
                        Triggered(tSource);
                    break;
                case 'S':
                    if (vSecondaryInput)
                        Triggered(tSource);
                    break;
                case 'T':
                    if (vTertiaryInput)
                        Triggered(tSource);
                    break;

            }
        }
    }
    
    void Triggered(Scr_Mechanism_System tSource)
    {
        GameObject tAmmo;
        switch (vType)
        {
            default:
                Debug.Log("Out has not been setup for " + this.name);

                break;
            case "Projectile":
                //tAmmo = tSource.RequestAmmo(vAmmoRequirement, vEnergyRequirement, vFuelRequirement);


                break;
        }
    }

    void Update()
    {
        if (vCoolDown > 0f)
        {
            vCoolDown -= Time.deltaTime;
        }
        else
        {
            this.enabled = false;
        }
    }



}
