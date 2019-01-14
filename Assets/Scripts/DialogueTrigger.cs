using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueTrigger : MonoBehaviour {

    [SerializeField]
    private ObjectInteraction _object;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (_object.dialogues != null)
        {
            Dialogue.instance.GetDialogues(_object.dialogues);
            //Debug.Log (_object.dialogues);
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogue>().StartDialogue();
    }
}
