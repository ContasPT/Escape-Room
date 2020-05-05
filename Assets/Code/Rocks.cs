using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    
    public List<GameObject> FloatingRocks;

    public static Rocks PuzzelManager;

     int currentRock = 0;

    // Start is called before the first frame update
    void Start()
    {
        PuzzelManager = this;
    }

    public void spawnRocks()
    {
        if (!(currentRock >= FloatingRocks.Count))
        {
            FloatingRocks[currentRock].SetActive(true);
            currentRock++;
        }
    }

}
