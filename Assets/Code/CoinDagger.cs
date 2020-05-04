using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDagger : InteractiveObject
{
    public override void ExecuteInteractiveAction()
    {

        if (InventoryManager.TheInventory.HasItem("Knife") && InventoryManager.TheInventory.HasItem("Bronze coin"))
        {
            InventoryManager.TheInventory.RemoveItem("Knife");
            InventoryManager.TheInventory.RemoveItem("Bronze coin");
            Rocks.PuzzelManager.spawnRocks();
            GetComponent<AN_DoorScript>().isOpened = true;
        }
    }
}
