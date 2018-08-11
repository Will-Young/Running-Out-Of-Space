using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrop : MonoBehaviour, IDropHandler {

    public DropZone dropZone;
    public Inventory inventory;

    bool isOverPoint;
    bool insideZone;

    private void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        isOverPoint = dropZone.mouseOver;
        insideZone = dropZone.insideZone;
        RectTransform invPanel = transform as RectTransform;

        IInventoryItem item = gameObject.GetComponent<IInventoryItem>();

        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition)
            && insideZone == true
            && isOverPoint == true)
        {
            Debug.Log("Item Dropped inside zone");
            inventory.RemoveItem(item);
        }
    }
}
