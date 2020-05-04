using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : InteractiveObject
{

    public override void ExecuteInteractiveAction()
    {

        if(InventoryManager.TheInventory.HasItem(KeyItem))
        {
            InventoryManager.TheInventory.RemoveItem(KeyItem);

            Rocks.PuzzelManager.spawnRocks();

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }

            base.ExecuteInteractiveAction();
        }

        
    }

}
