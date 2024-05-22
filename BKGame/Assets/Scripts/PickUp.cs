using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public string itemName = "Default Item";
    public string itemType = "Default";
    private Renderer itemRenderer;

    private void Start()
    {
        itemRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with " + itemName);
            Item newItem = new Item(itemName + " ", 1, itemType);
            Inventory.instance.AddItem(newItem);
            
            if (itemRenderer != null)
            {
                itemRenderer.enabled = false;
            }
         
            Collider itemCollider = GetComponent<Collider>();
            if (itemCollider != null)
            {
                itemCollider.enabled = false;
            }

            gameObject.SetActive(false);
        }
    }
}