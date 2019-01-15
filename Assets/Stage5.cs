using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5 : MonoBehaviour {

    Dialogue dialogue;

    int flag = 0;

    public Transform parent;

    public DialogueObject[] prolog;
    public DialogueObject[] epilog;
    public DialogueObject[] choice_1;
    public DialogueObject[] choice_2;


    void Start () {
        HideChild();
        dialogue = Dialogue.instance;
        dialogue.isDialogue = true;
        StartCoroutine(WaitForDetik());
        ShowButton("Prolog");
    }

    private void Update()
    {
        if (flag == 1)
        {
            StopAllCoroutines();
        }
    }

    public void Epilog()
    {
        HideChild();
        dialogue.GetDialogues(epilog);
        Debug.Log("End");
    }

    public void Choice_1()
    {
        HideChild();
        dialogue.GetDialogues(choice_1);
        ShowButton("Choice1");
    }

    public void Prolog()
    {
        HideChild();
        dialogue.GetDialogues(prolog);
        ShowButton("Prolog");
    }

    public void Choice_2()
    {
        HideChild();
        dialogue.GetDialogues(choice_2);
        ShowButton("Choice2");
    }

    IEnumerator WaitForDetik()
    {
        yield return new WaitForSeconds(0.5f);
        dialogue.GetDialogues(prolog);
    }

    private void ShowButton(string s)
    {
        parent.Find(s).gameObject.SetActive(true);
    }

    private void HideChild()
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            GameObject child = parent.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
        flag = 0;
    }

}
