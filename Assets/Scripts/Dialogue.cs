using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    #region Singleton

    public static Dialogue instance = null; //Static instance of GameManager which allows it to be accessed by any other script.

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
        DontDestroyOnLoad(gameObject);

    }

    #endregion

    [SerializeField]
    private Queue<DialogueObject> dialogues;

	[SerializeField]
	private Text speaker;

	[SerializeField]
	private Text dial;

	[SerializeField]
	private GameObject panel;

	public bool isDialogue = false;

	void Start(){
        dialogues = new Queue<DialogueObject>();
		panel.SetActive (false);
	}

	void Update(){
		if (isDialogue) {
            if (Input.GetMouseButtonDown(0))
            {
                StartDialogue ();
            }	
		}
	}

	public void GetDialogues(DialogueObject[] dialogue){
        //Debug.Log("getting dialogue");
		dialogues.Clear ();
		foreach (DialogueObject d in dialogue) {
			dialogues.Enqueue (d);
		}
		panel.SetActive (true);
		isDialogue = true;
		StartDialogue ();
	}

	public void StartDialogue(){

		if (dialogues.Count == 0) {
			panel.SetActive (false);
			isDialogue = false;
			return;
		}
		DialogueObject temp = dialogues.Dequeue ();
		string _name = temp._name;
		string text = temp.dialogue;
        Debug.Log("Name: " + _name);
		speaker.text = _name;
        dial.text = text;
	}

}
