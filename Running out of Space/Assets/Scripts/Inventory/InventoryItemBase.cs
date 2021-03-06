﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemBase : MonoBehaviour, IInventoryItem {

    public virtual string Name
    {
        get
        {
            return "_base item_";
        }
    }

    public Sprite _Image;

    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnDrop()
    {
        gameObject.SetActive(true);
    }
}
