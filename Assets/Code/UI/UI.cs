using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Menu;
    public GameObject ButtonStart;
    public GameObject ButtonResume;
    public GameObject InGame;
    public Text Sub;

    private void Start()
    {
        Player.GetComponent<FirstPersonController>().enabled = false;
        InGame.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            InGame.SetActive(false);
            Menu.SetActive(true);
            Player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    public void StartGame()
    {
        ButtonStart.SetActive(false);
        ButtonResume.SetActive(true);

        Menu.SetActive(false);

        if (Player.GetComponent<Animation>())
        {      

          StartCoroutine(PlayerControl());
        }
        else
        {
            InGame.SetActive(true);
            Player.GetComponent<FirstPersonController>().enabled = true;

        }


    }

    IEnumerator PlayerControl()
    {
        SFXManager.TheSFXGuy.PlaySFX("Voice1");
        Sub.text = "They told me I should grab that crystal and get out.";

        yield return new WaitForSeconds(4);
        Sub.text = "";

       Player.GetComponent<Animation>().Play("PlayerStart");

        yield return new WaitForSeconds(Player.GetComponent<Animation>().GetClip("PlayerStart").length);

        InGame.SetActive(true);
        //Player.GetComponent<FirstPersonController>().enabled = true;
        UIManager.TheUI.LockInput(true);
        SFXManager.TheSFXGuy.PlaySFX("Voice2");
        Sub.text = "Oh no, seems like I am stuck between a rock and a hard place.";

        yield return new WaitForSeconds(4);
        Sub.text = "";
    }

    public void ResumeGame()
    {
        Menu.SetActive(false);
        InGame.SetActive(true);
        Player.GetComponent<FirstPersonController>().enabled = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
