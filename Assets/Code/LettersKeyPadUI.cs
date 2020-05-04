using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LettersKeyPadUI : MonoBehaviour
{
    public string Password;
    public Text KeypadText;
    public bool Pass;

    // Start is called before the first frame update
    void Start()
    {
        KeypadText.text = "";
        Pass = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
        {
            KeypadText.text = Input.compositionString;
        }
    }

    public void PassChecker()
    {


            

        //if (
        //    (KeypadText.text.Length == 4) &&
        //    (KeypadText.text == Password)
        //    )
        //{
        //    SFXManager.TheSFXGuy.PlaySFX("Success");
        //    LED.color = Green;

        //    Pass = true;
        //    leaveKeypad();
        //}
        //else
        //{
        //    SFXManager.TheSFXGuy.PlaySFX("Fail");
        //    LED.color = Red;
        //    KeypadText.text = "";
        //    StartCoroutine(GoBackToGray());
        //}

    }

    public void Clear()
    {
        KeypadText.text = "";
    }

    public void leaveKeypad()
    {
        print("1");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        UIManager.TheUI.LockInput(true);


    }
}
