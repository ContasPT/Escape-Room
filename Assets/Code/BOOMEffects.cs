using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOOMEffects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BOOM());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator BOOM()
    {
        yield return new WaitForSeconds(3.75f);
        gameObject.SetActive(false);
    }
}
