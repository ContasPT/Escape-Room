using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class KeyPadLettersOpen : InteractiveObject
{
    public GameObject KeyPadUI;
    public string Password;

    public void PassKeypad()
    {
       
    }

    public override void ExecuteInteractiveAction()
    {

        KeyPadUI.GetComponent<LettersKeyPadUI>().Password = Password;

        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        KeyPadUI.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (KeyPadUI.activeSelf && KeyPadUI.GetComponent<LettersKeyPadUI>().Password == Password && KeyPadUI.GetComponent<LettersKeyPadUI>().Pass)
        {
            print("KeypadLetter enable");
            PassKeypad();
            print("Pass");
            KeyPadUI.SetActive(false);
            gameObject.tag = "Untagged";
        }
    }
}
