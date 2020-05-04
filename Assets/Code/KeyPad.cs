using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : InteractiveObject
{
    public GameObject KeyPadUI;
    public string Password;

    public virtual void PassKeypad()
    {

    }

    public override void ExecuteInteractiveAction()
    {

        KeyPadUI.GetComponent<KeypadUI>().Password = Password;

        UIManager.TheUI.LockInput(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        KeyPadUI.SetActive(true);
    }

    private void Update()
    {
        if (KeyPadUI.activeSelf && KeyPadUI.GetComponent<KeypadUI>().Password == Password && KeyPadUI.GetComponent<KeypadUI>().Pass)
        {
            PassKeypad();
            print("Pass");
            KeyPadUI.SetActive(false);
            gameObject.tag = "Untagged";
        }
    }

    
}
