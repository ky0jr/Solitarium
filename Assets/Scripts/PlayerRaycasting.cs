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

    [SerializeField]
    private Transform touchPanel;

    public string ObjectName = "";

    private RaycastHit hitInfo;
    private InteracableObject _object;
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

                

        //Draws ray in scene view during playmode; the multiplication in the second parameter controls how long the line will be
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        //A raycast returns a true or false value
        //we  initiate raycast through the Physics class
        //out parameter is saying take collider information of the object we hit, and push it out and 
        //store is in the what I hit variable. The variable is empty by default, but once the raycast hits
        //any collider, it's going to take the information, and store it in whatIHit variable. So then,
        //if I wanted to access something, I could access it through the whatIHit variable. 

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, distanceToSee, mask))        {
            
            _object = hitInfo.collider.GetComponent<ObjectInteraction>()._object;
            //ObjectName = hitInfo.collider.gameObject.name;
            Debug.Log("Saya pukul " + _object._name);
            highlight.text = _object._name;
            highlight.gameObject.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact(_object, hitInfo);         
            }
            
        }
        else
        {
            //ObjectName = "";
            highlight.gameObject.SetActive(false);
            
        }        
    }

    public void Interact(InteracableObject _object, RaycastHit hitInfo)
    {
        GameManager.instance.interact = true;


        description.text = _object.description;
        panel.SetActive(true);
        if (_object.isClue && !Inventory.instance.SameObject(_object))
        {
            Inventory.instance.Add(_object);
            if (_object.isPickupable)
            {
                Destroy(hitInfo.collider.gameObject);
            }

            //tambahan tanggal 6 novemeber 2018 untuk dapatkan return object
            Debug.Log(Inventory.instance.items.Find(FindItem));
        }
    }

    public void InteractButton()
    {
        if (!GameManager.instance.interact && Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, distanceToSee, mask))
        {
            Interact(_object, hitInfo);
            touchPanel.gameObject.SetActive(false);
        }            
        else
        {
            GameManager.instance.interact = false;
            panel.SetActive(false);
            touchPanel.gameObject.SetActive(true);
        }
            
    }


    //method di List<InteractableObject> untuk jadi System.Predicate
    public bool FindItem(InteracableObject find)
    {       
        return (find == _object);
    }
}
