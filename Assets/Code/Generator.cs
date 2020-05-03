using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : InteractiveObject
{

   

    public InventoryManager Inventory;

    // Start is called before the first frame update
    void Start()
    {
     
    }


    public override void ExecuteInteractiveAction()
    {

        if(InventoryManager.TheInventory.HasItem(KeyItem))
        {
            InventoryManager.TheInventory.RemoveItem(KeyItem);

            

            for (int i = 0; i < transform.GetChildCount(); i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        base.ExecuteInteractiveAction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
