using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "new Object", menuName = "InteracableObject")]
public class InteractableObject : ScriptableObject {

    public string _name = "name";

    [TextArea]
    public string description = "";

    public Sprite icon;

    public bool isPickupable = false;

    public bool isClue = false;

    public bool isCombineable = false;
}
