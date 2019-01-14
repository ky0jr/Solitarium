using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour {

    [SerializeField]
    private DialogueObject[] dialogues;
    [SerializeField]
    private SubmitGame submit;

    private void Start()
    {
        Dialogue.instance.GetDialogues(dialogues);
        StopAllCoroutines();
        submit.StartCoroutine("WaitForInput");
    }

    public void Load(string name)
    {
        SceneManager.LoadScene(name);
    }

}
