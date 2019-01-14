using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null; //Static instance of GameManager which allows it to be accessed by any other script.

    public bool interact = false;

    [SerializeField]
    private InteractableObject[] submit;

    [SerializeField]
    private DialogueObject[] prologue;
    [SerializeField]
    private DialogueObject[] epilogue;

    private Scene scene;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        Dialogue.instance.GetDialogues(prologue);
    }

    public bool CheckSubmit()
    {
        bool tf = true;
        foreach(InteractableObject @object in submit)
        {
            if (!Inventory.instance.items.Contains(@object))
            {
                Debug.Log("Not Complete");
                tf = false;
                return tf;
                
            }
        }
        Debug.Log("Complete");
        Dialogue.instance.GetDialogues(epilogue);
        return tf;
    }

    public string GetScene()
    {
        scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        return sceneName;
    }

}
