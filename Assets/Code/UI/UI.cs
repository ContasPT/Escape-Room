using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Menu;
    public GameObject ButtonStart;
    public GameObject ButtonResume;
    public GameObject InGame;

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
            Player.GetComponent<Animation>().Play("PlayerStart");

          

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

            yield return new WaitForSeconds(Player.GetComponent<Animation>().GetClip("PlayerStart").length);

        InGame.SetActive(true);
        Player.GetComponent<FirstPersonController>().enabled = true;
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
