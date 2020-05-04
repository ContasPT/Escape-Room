using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCart : InteractiveObject
{
    public GameObject Explosion;
    public GameObject Path;

    public float time;

    public override void ExecuteInteractiveAction()
    {
        if (InventoryManager.TheInventory.HasItem(KeyItem))
        {
            Rocks.PuzzelManager.spawnRocks();
            GetComponent<Animation>().Play();

            StartCoroutine(OpenPath());

            base.ExecuteInteractiveAction();
        }

        
    }

    public IEnumerator OpenPath()
    {
        yield return new WaitForSeconds(time);
        Explosion.SetActive(true);
        Path.SetActive(false);
    }
}


