using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour {

    public Inventory inventory;

    private void Update()
    {
        //ItemPosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInventoryItem item = collision.gameObject.GetComponent<IInventoryItem>();

        if (collision.gameObject.CompareTag("Item"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            if (Input.GetKeyDown("space"))
            {
                inventory.AddItem(item);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IInventoryItem item = collision.gameObject.GetComponent<IInventoryItem>();
        if (Input.GetKeyDown("space"))
        {
            inventory.AddItem(item);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

}
