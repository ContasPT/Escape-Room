using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DocumentManager : MonoBehaviour
{
    public GameObject DocPanel;

    public GameObject OverlayTextPanel;
    public Image DocOnScreen;
    public Text DocTextOnScreen;
    private string CachedDocText;

    public static DocumentManager TheManager;

    public enum TextState
    {
        Appearing,
        Hiding,
        Opaque,
        Transparent
    }
    public TextState CurrentTextState;
    private float AlphaColor = 0;
    public float AlphaColorRate;

    public float TextBackgroundAlphaOffset;

    void Start()
    {
        TheManager = this;
    }

    void Update()
    {
        switch (CurrentTextState)
        {
            case TextState.Appearing:
                AlphaColor += AlphaColorRate;//

                if(AlphaColor>=1)//
                {
                    AlphaColor = 1;//
                    CurrentTextState = TextState.Opaque;//
                }

                DocTextOnScreen.color = new Color(1, 1, 1, AlphaColor);
                OverlayTextPanel.GetComponent<Image>().color = new Color(0, 0, 0,
                    AlphaColor - TextBackgroundAlphaOffset);
                break;
            case TextState.Hiding:
                AlphaColor -= AlphaColorRate;

                if (AlphaColor <= 0)
                {
                    AlphaColor = 0;
                    CurrentTextState = TextState.Transparent;
                }

                DocTextOnScreen.color = new Color(1, 1, 1, AlphaColor);
                OverlayTextPanel.GetComponent<Image>().color = new Color(0, 0, 0,
                    AlphaColor - TextBackgroundAlphaOffset);
                break;
        }

        if(DocPanel.activeInHierarchy && Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentTextState == TextState.Opaque)
                HideText();
            else if (CurrentTextState == TextState.Transparent)
                ShowText();
        }

        if(Input.GetKeyDown(KeyCode.Escape) && DocPanel.activeInHierarchy)
        {
            CloseDocumentPanel();
        }
    }

    #region Document Utilities

    private void CloseDocumentPanel()
    {
        HideText(true);
        DocPanel.SetActive(false);
        UIManager.TheUI.LockInput(true);
    }

    public void ShowText()
    {
        CurrentTextState = TextState.Appearing;
    }

    private void HideText(bool DisableImmediately = false)
    {
        if(DisableImmediately)
        {
            CurrentTextState = TextState.Transparent;
            AlphaColor = 0;
            DocTextOnScreen.color = new Color(1, 1, 1, 0);
            OverlayTextPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        else
        {
            CurrentTextState = TextState.Hiding;
        }
    }

    internal void OpenDocumentPanel(Sprite Img, string DocName, string DocText)
    {
        DocPanel.SetActive(true);
        DocOnScreen.sprite = Img;
        CachedDocText = "<size=25>[" + DocName + "]</size>\n\n" + DocText;
        DocTextOnScreen.text = CachedDocText;

        //Lock The Inputs
        UIManager.TheUI.LockInput(false);

        DocTextOnScreen.color = new Color(1, 1, 1, 0);
        OverlayTextPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        CurrentTextState = TextState.Transparent;
    }

    internal void OpenDocumentPanel(DocumentScript DS)
    {
        OpenDocumentPanel(DS.DocSprite, DS.DocName, DS.DocText);
    }

    #endregion
}
