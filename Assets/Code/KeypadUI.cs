using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadUI : MonoBehaviour
{
    public string Password;
    
    public Text KeypadText;

    public Color Red;
    public Color Green;
    private Color Original;

    public Image LED;
    public bool IhaveTyped4;

    public bool Pass;

    void Start()
    {
        KeypadText.text = "";
        Original = LED.color;
        Pass = false;


    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) && gameObject.activeSelf)
        {
            leaveKeypad();

            gameObject.SetActive(false);
        }
    }

    public void ClickOnBtn(string Val)
    {
        if (IhaveTyped4) return;

       // if(KeypadText.text=="0000")KeypadText.text = "";
        KeypadText.text += Val;
        SFXManager.TheSFXGuy.PlaySFX("Beep");

        if(KeypadText.text.Length == 11)
        {
            IhaveTyped4 = true;
            StartCoroutine(PassCheckerCoRoutine());
        }
    }

    public IEnumerator PassCheckerCoRoutine()
    {
        yield return new WaitForSeconds(1);
        PassChecker();
        IhaveTyped4 = false;
    }

    public void PassChecker()
    {
        if (
            (KeypadText.text == Password)
            )
        {
            SFXManager.TheSFXGuy.PlaySFX("Success");
            LED.color = Green;

            Pass = true;
            leaveKeypad();
        }
        else
        {
            SFXManager.TheSFXGuy.PlaySFX("Fail");
            LED.color = Red;
            KeypadText.text = "";
            StartCoroutine(GoBackToGray());
        }

    }
    public IEnumerator GoBackToGray()
    {
        yield return new WaitForSeconds(3);
        LED.color = Original;
    }

    public void Clear()
    {
        KeypadText.text = "";
    }

    public void Delete()
    {
        KeypadText.text = KeypadText.text.Remove(KeypadText.text.Length - 1, 1);
    }

    public void leaveKeypad()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        UIManager.TheUI.LockInput(true);

        
    }
}
