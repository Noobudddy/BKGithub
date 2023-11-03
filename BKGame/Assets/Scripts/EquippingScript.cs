using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippingScript : MonoBehaviour
{
    public PlayerEquipmentManager equipmentManager;

    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;

    void Start()
    {
        Equip0();
    }

    bool HasItem(string itemType)
    {
        foreach (Item item in Inventory.instance.items)
        {
            if (item.itemType == itemType)
            {
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Equip1();
        }

        if (Input.GetKeyDown("2"))
        {
            Equip2();
        }

        if (Input.GetKeyDown("3"))
        {
            Equip3();
        }

        if (Input.GetKeyDown("0"))
        {
            Equip0();
        }
    }

    void EquipItem(Item item)
    {
        switch (item.itemType)
        {
            case "Grappling":
                break;
            case "Swinging":
                break;
            case "Melee":
                break;
            case "Fireball":
                break;
        }
    }

    void Equip0()
    {
        Slot1.SetActive(false);
        Slot2.SetActive(false);
        Slot3.SetActive(false);

        equipmentManager.DisableGrappling();
        equipmentManager.DisableSwinging();
        equipmentManager.DisableMelee();
        equipmentManager.DisableFireball();
    }

    void Equip1()
    {
        Slot1.SetActive(true);
        Slot2.SetActive(false);
        Slot3.SetActive(false);

        bool hasGrappling = false;
        bool hasSwinging = false;

        foreach (Item item in Inventory.instance.items)
        {
            if (item.itemType == "Utility")
            {
                hasGrappling = true;
                hasSwinging = true;
            }
        }

        // Enable or disable abilities based on the accumulated flags
        if (hasGrappling)
        {
            equipmentManager.EnableGrappling();
        }
        else
        {
            equipmentManager.DisableGrappling();
        }

        if (hasSwinging)
        {
            equipmentManager.EnableSwinging();
        }
        else
        {
            equipmentManager.DisableSwinging();
        }

        equipmentManager.DisableMelee();
        equipmentManager.DisableFireball();
    }


    void Equip2()
    {
        Slot1.SetActive(false);
        Slot2.SetActive(true);
        Slot3.SetActive(false);

        bool hasMelee = false;

        foreach (Item item in Inventory.instance.items)
        {
            if (item.itemType == "Melee")
            {
                hasMelee = true;
            }
        }

        if (hasMelee)
        {
            equipmentManager.EnableMelee();
        }
        else
        {
            equipmentManager.DisableMelee();
        }

        equipmentManager.DisableGrappling();
        equipmentManager.DisableSwinging();
        equipmentManager.DisableFireball();
    }

    void Equip3()
    {
        Slot1.SetActive(false);
        Slot2.SetActive(false);
        Slot3.SetActive(true);

        bool hasFireball = false;

        foreach (Item item in Inventory.instance.items)
        {
            if (item.itemType == "Projectile")
            {
                hasFireball = true;
            }
        }

        if (hasFireball)
        {
            equipmentManager.EnableFireball();
        }
        else
        {
            equipmentManager.DisableFireball();
        }

        equipmentManager.DisableGrappling();
        equipmentManager.DisableSwinging();
        equipmentManager.DisableMelee();
    }
}
