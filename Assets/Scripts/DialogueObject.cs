﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Dialogue", menuName = "Dialogue")]
public class DialogueObject : ScriptableObject {

    public string _name = "name";
    
    [TextArea]
    public string dialogue = "";

}