using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : InteractiveObject
{
    public override void ExecuteInteractiveAction()
    {
        if (InventoryManager.TheInventory.HasItem(KeyItem))
        {
            GetComponent<AN_DoorScript>().isOpened = true;

            base.ExecuteInteractiveAction();
        }
    }
}
