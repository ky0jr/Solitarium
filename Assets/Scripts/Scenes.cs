using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour {

    [SerializeField]
    DialogueObject[] dialogues;

    private void Start()
    {
        Dialogue.instance.GetDialogues(dialogues);    
    }

    public void Load(string name)
    {
        SceneManager.LoadScene(name);
    }
}
