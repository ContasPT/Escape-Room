using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastVoice : MonoBehaviour
{

    public Text Sub;
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Collider>().enabled = false;

        StartCoroutine(LastvoiceLine());

    }

    IEnumerator LastvoiceLine()
    {
        SFXManager.TheSFXGuy.PlaySFX("Voice3");
        Sub.text = "Finally I'm free, feels great to get some fresh air.";

        yield return new WaitForSeconds(4);
        Sub.text = "";
    }

}
