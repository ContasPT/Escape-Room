using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDoor : InteractiveObject
{

    public bool keypad = false;

    public override void ExecuteInteractiveAction()
    {
        if (InventoryManager.TheInventory.HasItem(KeyItem) && keypad)
        {
            GetComponent<AN_DoorScript>().isOpened = true;
;
            base.ExecuteInteractiveAction();
        }
    }
}
