using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueTrigger : MonoBehaviour {

    public DialogueObject[] dialogue;
    
	// Use this for initialization
	void Start () {
        Dialogue.instance.isDialogue = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogue>().StartDialogue();
    }
}
