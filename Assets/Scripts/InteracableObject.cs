using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "new Object", menuName = "InteracableObject")]
public class InteracableObject : ScriptableObject {

    public string _name = "name";

    [TextArea]
    public string description = "";

    public bool isPickupable = false;

	
}
