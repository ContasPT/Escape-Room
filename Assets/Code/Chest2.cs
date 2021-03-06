﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest2 : InteractiveObject
{
    public bool keypad = false;

    public override void ExecuteInteractiveAction()
    {
        if (InventoryManager.TheInventory.HasItem(KeyItem) && keypad)
        {
            InventoryManager.TheInventory.RemoveItem(KeyItem);

            GetComponent<Animation>().Play();

            GetComponent<BoxCollider>().enabled = false;

            Rocks.PuzzelManager.spawnRocks();
            base.ExecuteInteractiveAction();
        }
    }
}
