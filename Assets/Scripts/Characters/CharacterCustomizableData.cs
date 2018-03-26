using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterCustomizableData {

    //public because of unity's JSON read/write
    public string name = "test";
    public int currentAnimation = 0;
    public int currentStyle = 0;

}
