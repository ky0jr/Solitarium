using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject {

    public InteractableObject input1;
    public InteractableObject input2;

    public InteractableObject result;


}
