using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

    [SerializeField]
    private DialogueObject[] part1;
    [SerializeField]
    private GameObject button1;
    [SerializeField]
    private GameObject button2;

    //wrong
    [SerializeField]
    private DialogueObject[] part2;
    //correct
    [SerializeField]
    private DialogueObject[] part3;

    [SerializeField]
    private DialogueObject[] part4;
    [SerializeField]
    private GameObject button3;
    [SerializeField]
    private GameObject button4;

    //wrong
    [SerializeField]
    private DialogueObject[] wrong1;
    //correct
    [SerializeField]
    private DialogueObject[] correct1;

    [SerializeField]
    private DialogueObject[] part5;
    [SerializeField]
    private GameObject button5;
    [SerializeField]
    private GameObject button6;

    //wrong
    [SerializeField]
    private DialogueObject[] wrong2;
    //correct
    [SerializeField]
    private DialogueObject[] correct2;

    [SerializeField]
    private DialogueObject[] part6;
    [SerializeField]
    private GameObject button7;
    [SerializeField]
    private GameObject button8;

    //wrong
    [SerializeField]
    private DialogueObject[] wrong3;
    //correct
    [SerializeField]
    private DialogueObject[] correct3;

    [SerializeField]
    private DialogueObject[] died;
    [SerializeField]
    private DialogueObject[] win;

    private bool wrong = false;

    [SerializeField]
    private GameObject continue1;
    [SerializeField]
    private GameObject continue2;
    [SerializeField]
    private GameObject continue3;
    [SerializeField]
    private GameObject continue4;
    [SerializeField]
    private GameObject continue5;
    [SerializeField]
    private GameObject endGame;

    // Use this for initialization
    void Start() {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        button5.SetActive(false);
        button6.SetActive(false);
        button7.SetActive(false);
        button8.SetActive(false);
        continue1.SetActive(false);
        continue2.SetActive(false);
        continue3.SetActive(false);
        continue4.SetActive(false);
        continue5.SetActive(false);
        endGame.SetActive(false);
        DialogueGoTo1();
    }

    // Update is called once per frame
    void Update() {
        
    }
    public void DialogueGoTo1()
    {
        Dialogue.instance.GetDialogues(part1);
        button1.SetActive(true);
        button2.SetActive(true);
    }
    //choice wrong
    public void DialogueGoTo2()
    {
        Dialogue.instance.GetDialogues(part2);
        button1.SetActive(false);
        button2.SetActive(false);
        wrong = true;
        continue1.SetActive(true);
    }
    //choice true
    public void DialogueGoTo3()
    {
        Dialogue.instance.GetDialogues(part3);
        button1.SetActive(false);
        button2.SetActive(false);
        continue1.SetActive(true);
    }
    public void DialogueGoTo4()
    { 
        Dialogue.instance.GetDialogues(part4);
        button3.SetActive(true);
        button4.SetActive(true);
        continue1.SetActive(false);
    }
    //choice wrong
    public void DialogueGoTo5()
    {
        Dialogue.instance.GetDialogues(wrong1);
        button3.SetActive(false);
        button4.SetActive(false);
        wrong = true;
        continue2.SetActive(true);
        
    }
    //choice true
    public void DialogueGoTo6()
    {
        Dialogue.instance.GetDialogues(correct1);
        button3.SetActive(false);
        button4.SetActive(false);
        continue2.SetActive(true);
    }

    public void DialogueGoTo7()
    {
        Dialogue.instance.GetDialogues(part5);
        button5.SetActive(true);
        button6.SetActive(true);
        continue2.SetActive(false);
    }

    //choice wrong 2
    public void DialogueGoTo8()
    {
        Dialogue.instance.GetDialogues(wrong2);
        button5.SetActive(false);
        button6.SetActive(false);
        wrong = true;
        continue3.SetActive(true);
    }
    //choice true 2
    public void DialogueGoTo9()
    {
        Dialogue.instance.GetDialogues(correct2);
        button5.SetActive(false);
        button6.SetActive(false);
        continue3.SetActive(true);
    }

    //part6
    public void DialogueGoTo10()
    {
        Dialogue.instance.GetDialogues(part6);
        button7.SetActive(true);
        button8.SetActive(true);
        continue3.SetActive(false);
    }
    //choice wrong3
    public void DialogueGoTo11()
    {
        Dialogue.instance.GetDialogues(wrong3);
        button7.SetActive(false);
        button8.SetActive(false);
        wrong = true;
        continue4.SetActive(true);
    }
    //choice true 3
    public void DialogueGoTo12()
    {
        Dialogue.instance.GetDialogues(correct3);
        button7.SetActive(false);
        button8.SetActive(false);
        if (wrong)
        {
            continue4.SetActive(true);
        } else continue5.SetActive(true);
    }
    //died
    public void DialogueDied()
    {
        Dialogue.instance.GetDialogues(died);
        continue4.SetActive(false);
        endGame.SetActive(true);
    }
    //win
    public void DialogueWin()
    {
        Dialogue.instance.GetDialogues(win);
        continue5.SetActive(false);
        endGame.SetActive(true);
    }

    public void GoToMainMenu(string name)
    {
        SceneManager.LoadScene(name);
    }
}
