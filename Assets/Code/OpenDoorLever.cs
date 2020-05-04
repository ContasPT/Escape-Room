using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorLever : MonoBehaviour
{

    public Lever Lever1;
    public Lever Lever2;
    public Lever Lever3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lever1.State && Lever2.State && !Lever3.State)
        {
            GetComponent<AN_DoorScript>().isOpened = true;

            Rocks.PuzzelManager.spawnRocks();

            this.enabled = false;
        }
    }
}
