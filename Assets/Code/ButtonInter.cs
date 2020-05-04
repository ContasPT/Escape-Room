using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInter : InteractiveObject
{
    Light light;

    public float fadetime;
    float currenttime;
    float Normalintensity;

    public ButtonPuzzel.Buttons Type;

    // Start is called before the first frame update
    void Start()
    {
        light = transform.GetChild(1).GetComponent<Light>();
        Normalintensity = light.intensity;
        light.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currenttime > 0)
        {
            light.intensity = currenttime * Normalintensity / fadetime;

            currenttime -= Time.deltaTime;
        }
    }

    public override void ExecuteInteractiveAction()
    {
        Light();
        transform.parent.gameObject.GetComponent<ButtonPuzzel>().PressButton(Type);
    }

    public void Light()
    {
        currenttime = fadetime;
    }
}
