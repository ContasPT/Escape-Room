using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest1 : InteractiveObject
{
    public override void ExecuteInteractiveAction()
    {
        if (InventoryManager.TheInventory.HasItem(KeyItem))
        {
            GetComponent<Animation>().Play();

            GetComponent<BoxCollider>().enabled = false
;
            base.ExecuteInteractiveAction();
        }
    }

}
