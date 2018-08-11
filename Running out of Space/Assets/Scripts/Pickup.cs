using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public Inventory inventory;

    bool isMouseOver = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInventoryItem item = gameObject.GetComponent<IInventoryItem>();

        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            if (Input.GetMouseButtonDown(0) && isMouseOver == true)
            {
                inventory.AddItem(item);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IInventoryItem item = gameObject.GetComponent<IInventoryItem>();
        if (Input.GetMouseButtonDown(0) && isMouseOver == true)
        {
            inventory.AddItem(item);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void OnMouseEnter()
    {
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }
}
