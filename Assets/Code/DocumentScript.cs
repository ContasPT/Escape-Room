﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocumentScript : MonoBehaviour
{
    public Sprite DocSprite;

    public string DocName;

    [TextArea(1,20)]
    public string DocText;
}
