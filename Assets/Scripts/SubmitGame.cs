using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubmitGame : MonoBehaviour {

    [SerializeField]
    private DialogueObject[] blackCubes;
    [SerializeField]
    private DialogueObject[] wrong;
    int flag = 0;

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            
            if (GameManager.instance.CheckSubmit())
            {
                StartCoroutine("WaitForInput");
            }
            else
            {
                if(flag == 0)
                {
                    Dialogue.instance.GetDialogues(blackCubes);
                    flag++;
                }
                if (flag == 1 && Inventory.instance.items.Count != 0)
                {
                    Dialogue.instance.GetDialogues(wrong);
                    flag++;
                }
                    
                
            }
        }
        

    }

    IEnumerator WaitForInput()
    {
        while (!Input.GetMouseButtonDown(0)||Dialogue.instance.isDialogue)//!Input.GetKeyDown(KeyCode.Space))
            yield return null; 
        SceneManager.LoadScene("Main Menu");
    }
}
