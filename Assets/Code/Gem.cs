using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : InteractiveObject
{
    public override void ExecuteInteractiveAction()
    {

        if (InventoryManager.TheInventory.HasItem(KeyItem))
        {
            Rocks.PuzzelManager.spawnRocks();

            InventoryManager.TheInventory.RemoveItem(KeyItem);

            InventoryManager.TheInventory.AddItem(
                    GetComponent<InventoryPickup>().AssociatedItem);
            gameObject.SetActive(false);
        }
    }
}
