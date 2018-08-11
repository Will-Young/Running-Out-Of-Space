using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour {

    public Inventory Inventory;

    private void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach(Transform slot in inventoryPanel)
        {
            // Border image
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            ItemDrag itemDrag = imageTransform.GetComponent<ItemDrag>();

            // There is an empty slot available
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                // Store a reference to the item
                itemDrag.Item = e.Item;

                break;
            }
        }
    }

    void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach(Transform slot in inventoryPanel)
        {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDrag itemDrag = imageTransform.GetComponent<ItemDrag>();

            // Find item in the UI
            if (itemDrag.Item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;
                itemDrag.Item = null;
                break;
            }
        }

    }
}
