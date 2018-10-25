using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycasting : MonoBehaviour {

    [SerializeField]
    private float distanceToSee;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private Text highlight;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private Text description;

    public string ObjectName = "";    

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.interact == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {                
                GameManager.instance.interact = false;                
                panel.SetActive(false);
                return;
            }
        }

        RaycastHit hitInfo;        

        //Draws ray in scene view during playmode; the multiplication in the second parameter controls how long the line will be
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        //A raycast returns a true or false value
        //we  initiate raycast through the Physics class
        //out parameter is saying take collider information of the object we hit, and push it out and 
        //store is in the what I hit variable. The variable is empty by default, but once the raycast hits
        //any collider, it's going to take the information, and store it in whatIHit variable. So then,
        //if I wanted to access something, I could access it through the whatIHit variable. 

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, distanceToSee, mask))
        {           
            
            ObjectName = hitInfo.collider.gameObject.name;
            Debug.Log("Saya pukul " + ObjectName);
            highlight.text = ObjectName;
            highlight.gameObject.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                InteracableObject _object;                
                GameManager.instance.interact = true;

                _object = GameManager.instance.FindObject(ObjectName);
                description.text = _object.description;
                panel.SetActive(true);
                if (_object.isClue)
                {
                    Inventory.instance.Add(_object);
                    if (_object.isPickupable)
                    {
                        Destroy(hitInfo.collider.gameObject);
                    }                    
                }                   
                
            }
            
        }
        else
        {
            ObjectName = "";
            highlight.gameObject.SetActive(false);
            
        }        
    }

}
