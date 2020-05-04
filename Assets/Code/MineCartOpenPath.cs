using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCartOpenPath : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject minecart;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other == minecart)
        {
            
            Explosion.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
