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

        equipmentManager.EnableGrappling();
        equipmentManager.EnableSwinging();
        equipmentManager.DisableMelee();
        equipmentManager.DisableFireball();
    }

    void Equip2()
    {
        Slot1.SetActive(false);
        Slot2.SetActive(true);
        Slot3.SetActive(false);

        equipmentManager.DisableGrappling();
        equipmentManager.DisableSwinging();
        equipmentManager.EnableMelee();
        equipmentManager.DisableFireball();
    }

    void Equip3()
    {
        Slot1.SetActive(false);
        Slot2.SetActive(false);
        Slot3.SetActive(true);

        equipmentManager.DisableGrappling();
        equipmentManager.DisableSwinging();
        equipmentManager.DisableMelee();
        equipmentManager.EnableFireball();
    }
}
