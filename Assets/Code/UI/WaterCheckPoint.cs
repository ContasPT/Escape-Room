using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCheckPoint : MonoBehaviour
{
    public GameObject Water;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Water.GetComponent<Water>().Pos = gameObject;
    }
}
