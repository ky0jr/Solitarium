using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public static Dialogue instance = null;

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
        DontDestroyOnLoad(gameObject);

    }

    [SerializeField]
    private GameObject dialoguePanel;
    [SerializeField]
    private Text dialogueText;
    [SerializeField]
    private Text _name;

    private GameManager gameManager;

    [SerializeField]
    private DialogueScene[] dialogueScene;

    private DialogueObject[] dialogueObj;

    // Use this for initialization
    void Start () {
        gameManager = GameManager.instance;
    }
	
	// Update is called once per frame
	void Update () {
		if(gameManager.sceneName == "Stage 1")
        {
            dialogueObj = dialogueScene[0].dialogues;
        }
        else if(gameManager.sceneName == "Stage 2")
        {
            dialogueObj = dialogueScene[1].dialogues;
        }
        else if (gameManager.sceneName == "Stage 3")
        {
            dialogueObj = dialogueScene[2].dialogues;
        }
        else if (gameManager.sceneName == "Stage 4")
        {
            dialogueObj = dialogueScene[3].dialogues;
        }
        else if (gameManager.sceneName == "Prologue")
        {
            dialogueObj = dialogueScene[4].dialogues;
        }
        else if (gameManager.sceneName == "Epilogue")
        {
            dialogueObj = dialogueScene[5].dialogues;
        }
    }
}
