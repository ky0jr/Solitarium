using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    #region Singleton

    public static Pause instance = null; //Static instance of GameManager which allows it to be accessed by any other script.

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

    #endregion

    public GameObject pausePanel;
    public bool pause = false;

    private void Start()
    {
        pause = false;
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
        if (pause == true)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
	}

    public void PauseButton()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        pause = !pause;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
