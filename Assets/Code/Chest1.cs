﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest1 : InteractiveObject
{
    public override void ExecuteInteractiveAction()
    {
        if (InventoryManager.TheInventory.HasItem(KeyItem))
        {
            InventoryManager.TheInventory.RemoveItem(KeyItem);
            GetComponent<Animation>().Play();

            GetComponent<BoxCollider>().enabled = false;
            Rocks.PuzzelManager.spawnRocks();
            base.ExecuteInteractiveAction();
        }
    }

}
