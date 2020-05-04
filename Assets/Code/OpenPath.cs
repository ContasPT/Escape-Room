using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPath : InteractiveObject
{
    public GameObject Explosion;
    public override void ExecuteInteractiveAction()
    {

        if (InventoryManager.TheInventory.HasItem("Blue Flask") && InventoryManager.TheInventory.HasItem("Red Flask") && InventoryManager.TheInventory.HasItem("Green Flask"))
        {
            InventoryManager.TheInventory.RemoveItem("Blue Flask");
            InventoryManager.TheInventory.RemoveItem("Red Flask");
            InventoryManager.TheInventory.RemoveItem("Green Flask");
            Rocks.PuzzelManager.spawnRocks();
            Explosion.SetActive(true);

            transform.parent.gameObject.SetActive(false);
            base.ExecuteInteractiveAction();
        }

        
    }


}
