using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UIManager : MonoBehaviour
{
    public static UIManager TheUI;
    public FirstPersonController TheCharInputs;

    void Start()
    {
        TheUI = this;
    }

    public bool AreAnyUIsActive() // <3
    {
        if (DocumentManager.TheManager.DocPanel.activeInHierarchy) return true;
        if (InventoryManager.TheInventory.InventoryPanel.activeInHierarchy) return true;
        
        return false;
    }

    internal void LockInput(bool LockVal)
    {
        TheCharInputs.enabled = LockVal;
    }
}
