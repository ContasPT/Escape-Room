using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityStandardAssets.Characters.FirstPerson;

public class Water : MonoBehaviour
{

    public GameObject Pos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(teleport(other));
            
        }
    }

    IEnumerator teleport(Collider other)
    {
        // suspend execution for 5 seconds
        other.GetComponent<FirstPersonController>().enabled = false;
        other.transform.position = Pos.transform.position;
        yield return new WaitForSeconds(0.25f);
        while (other.transform.position != Pos.transform.position)
        {
            
        }
        other.GetComponent<FirstPersonController>().enabled = true;
    }
}
