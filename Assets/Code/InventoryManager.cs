using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> Items;
    public int InventoryLimit;
    public int CurrentInventoryIndex = 0;

    public List<GameObject> ItemSlots = new List<GameObject>();
    public List<GameObject> GlowSlots = new List<GameObject>();

    public GameObject IconsParent;
    public GameObject GlowParent;

    public GameObject InventoryPanel;

    public Sprite Empty;

    public Text NameTxt;
    public Text DescTxt;

    public GameObject FPSController;

    public GameObject CurItem_Frame;
    public Image CurItem_Image;

    public static InventoryManager TheInventory;
    private void Start()
    {
        TheInventory = this;

        for (int i = 0; i < IconsParent.transform.childCount; i++)
        {
            ItemSlots.Add(IconsParent.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < GlowParent.transform.childCount; i++)
        {
            GlowSlots.Add(GlowParent.transform.GetChild(i).gameObject);
        }

        foreach (var item in ItemSlots)
        {
            item.GetComponent<Image>().sprite = Empty;
        }

        InventoryPanel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            // Open the inventory if its not active
            if (!InventoryPanel.activeInHierarchy)
            {
                if (UIManager.TheUI.AreAnyUIsActive()) return;
                InventoryPanel.SetActive(true);
                UpdateInventory();
                CurItem_Frame.SetActive(false);
            }
            else // close the inventory
            {
                InventoryPanel.SetActive(false);
                if (CurrentInventoryIndex < Items.Count)
                {
                    CurItem_Frame.SetActive(true);
                    CurItem_Image.sprite = Items[CurrentInventoryIndex].Image;
                }
                else
                {
                    CurItem_Frame.SetActive(false);
                }
            }

            UIManager.TheUI.LockInput(!InventoryPanel.activeInHierarchy);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) || 
            Input.GetKeyDown(KeyCode.A))
        {
            if(CurrentInventoryIndex>0)///////////////////////
            {
                CurrentInventoryIndex--;
                UpdateInventory();
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.D))
        {
            if(CurrentInventoryIndex< InventoryLimit-1)///////////////////
            {
                CurrentInventoryIndex++;
                UpdateInventory();
            }
        }
    }

    private void UpdateInventory()
    {
        //Step 1: Update Item Slots
        for (int i = 0; i < InventoryLimit; i++)
        {
            ItemSlots[i].GetComponent<Image>().sprite = Empty;
        }
        for (int i = 0; i < Items.Count; i++)
        {
            ItemSlots[i].GetComponent<Image>().sprite = Items[i].Image;
        }

        // Step 2: Update the glow behind the slots.
        for (int i = 0; i < InventoryLimit; i++)
        {
            GlowSlots[i].SetActive(false);
        }
        GlowSlots[CurrentInventoryIndex].SetActive(true);

        // Step 3: update name/description tooltips
        if(CurrentInventoryIndex < Items.Count)
        {
            NameTxt.text = Items[CurrentInventoryIndex].Name;
            DescTxt.text = Items[CurrentInventoryIndex].Description;

            
        }
        else
        {
            NameTxt.text = "Empty";
            DescTxt.text = "No Item Selected";
        }

    }

    #region Inventory Utilities

    public void AddItem(InventoryItem X)
    {
        if(Items.Count == InventoryLimit)
        {
            print("Inventory Full!");
            return;
        }

        Items.Add(X);
    }

    public bool HasItem(string Name)
    {
        bool hasItem = false;
        foreach (var item in Items)
        {
            if (item.Name == Name) hasItem = true;
        }
        return hasItem;
    }

    public void RemoveItem(string Name)
    {
        if (HasItem(Name))
        {
            int INDX = GetIndexOfItem(Name);
            Items.RemoveAt(INDX);
        }
        UpdateInventory();
    }

    public void RemoveItem(int Index)
    {
        Items.RemoveAt(Index);
        UpdateInventory();
    }

    public int GetIndexOfItem(string Name)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name == Name) return i;
        }
        return -1;
    }

    public Sprite GetSpriteOfItem(string Name)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name == Name) return Items[i].Image;
        }

        return null;
    }

    #endregion

}

[System.Serializable]
public class InventoryItem
{
    public string Name;
    public string Description;
    public Sprite Image;
}



