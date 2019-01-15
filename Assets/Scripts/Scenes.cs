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
        if(Dialogue.instance != null)
        {
            Dialogue.instance.GetDialogues(dialogues);
            StopAllCoroutines();
            submit.StartCoroutine("WaitForInput");
        }
        
    }

    public void Load(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitApp()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
        #else
            Application.Quit();
        #endif
    }
}
