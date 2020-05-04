using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DocumentManager : MonoBehaviour
{
    public GameObject DocPanel;
    public Image DocOnScreen;

    public static DocumentManager TheManager;
    
    void Start()
    {
        TheManager = this;
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) && DocPanel.activeSelf)
        {
            CloseDocumentPanel();
        }
    }

    #region Document Utilities

    private void CloseDocumentPanel()
    {
        DocPanel.SetActive(false);
        UIManager.TheUI.LockInput(true);
    }

    internal void OpenDocumentPanel(Sprite Img)
    {

        DocPanel.SetActive(true);
        DocOnScreen.sprite = Img;

        //Lock The Inputs
        UIManager.TheUI.LockInput(false);

    }

    internal void OpenDocumentPanel(DocumentScript DS)
    {
        OpenDocumentPanel(DS.DocSprite);
    }

    #endregion
}
