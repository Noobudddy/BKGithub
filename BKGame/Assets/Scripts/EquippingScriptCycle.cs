using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippingScriptCycle : MonoBehaviour
{
    public PlayerEquipmentManager equipmentManager;

    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;

    private int currentItemIndex = 0;

    void Start()
    {
        // Disable all slots and equipment at the start
        Slot1.SetActive(false);
        Slot2.SetActive(false);
        Slot3.SetActive(false);

        equipmentManager.DisableGrappling();
        equipmentManager.DisableSwinging();
        equipmentManager.DisableMelee();
        equipmentManager.DisableFireball();

        EquipItem(); // Equip the first item
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentItemIndex = (currentItemIndex - 1 + Inventory.instance.items.Count) % Inventory.instance.items.Count;
            EquipItem();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentItemIndex = (currentItemIndex + 1) % Inventory.instance.items.Count;
            EquipItem();
        }
    }

    void EquipItem()
    {
        Slot1.SetActive(false);
        Slot2.SetActive(false);
        Slot3.SetActive(false);

        List<Item> items = Inventory.instance.items;

        if (items.Count == 0)
            return;

        Item currentItem = items[currentItemIndex];

        switch (currentItem.itemType)
        {
            case "Utility":
                Slot1.SetActive(true);
                break;
            case "Melee":
                Slot2.SetActive(true);
                break;
            case "Projectile":
                Slot3.SetActive(true);
                break;
        }

        // Enable or disable abilities based on the equipped item
        switch (currentItem.itemType)
        {
            case "Utility":
                equipmentManager.EnableGrappling();
                equipmentManager.EnableSwinging();
                equipmentManager.DisableMelee();
                equipmentManager.DisableFireball();
                break;
            case "Melee":
                equipmentManager.DisableGrappling();
                equipmentManager.DisableSwinging();
                equipmentManager.EnableMelee();
                equipmentManager.DisableFireball();
                break;
            case "Projectile":
                equipmentManager.DisableGrappling();
                equipmentManager.DisableSwinging();
                equipmentManager.DisableMelee();
                equipmentManager.EnableFireball();
                break;
        }
    }
}
