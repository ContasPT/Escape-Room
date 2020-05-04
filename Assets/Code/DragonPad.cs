using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPad : KeyPad
{
    public GameObject Door;

    public override void PassKeypad()
    {
        Door.GetComponent<DragonDoor>().keypad = true;
    }
}
