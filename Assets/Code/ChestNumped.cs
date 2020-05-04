using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestNumped : KeyPad
{
    public GameObject chest;

    public override void PassKeypad()
    {
        chest.GetComponent<Chest2>().keypad = true;
    }
}
