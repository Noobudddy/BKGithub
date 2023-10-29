using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentManager : MonoBehaviour
{
    public Grappling grapplingScript;
    public Swinging swingingScript;
    public Fireball fireballScript;
    public MeleeController meleeScript;
    public EquippingScript equipScript;

    public void EnableGrappling()
    {
        grapplingScript.enabled = true;
    }

    public void DisableGrappling()
    {
        grapplingScript.enabled = false;
    }

    public void EnableSwinging()
    {
        swingingScript.enabled = true;
    }

    public void DisableSwinging()
    {
        swingingScript.enabled = false;
    }

    public void EnableFireball()
    {
        fireballScript.enabled = true;
    }

    public void DisableFireball()
    {
        fireballScript.enabled = false;
    }

    public void EnableMelee()
    {
        meleeScript.enabled = true;
    }

    public void DisableMelee()
    {
        meleeScript.enabled = false;
    }
}
