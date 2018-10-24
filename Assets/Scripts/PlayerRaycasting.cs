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

    private Color highlightColor;

    Material originalMaterial, tempMaterial;

    Renderer rend = null;

    void Start()
    {
        highlightColor = Color.green;
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.interact == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("Ipress");
                GameManager.instance.interact = false;
                //highlight.gameObject.SetActive(true);
                panel.SetActive(false);
                return;
            }
        }

        RaycastHit hitInfo;
        Renderer currRend;

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
            
            currRend = hitInfo.collider.gameObject.GetComponent<Renderer>();
            ObjectName = hitInfo.collider.gameObject.name;
            highlight.text = ObjectName;
            highlight.gameObject.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                InteracableObject _object;
                //highlight.gameObject.SetActive(false);
                GameManager.instance.interact = true;

                _object = GameManager.instance.FindObject(ObjectName);
                description.text = _object.description;
                panel.SetActive(true);
                if (_object.isPickupable)
                    Destroy(hitInfo.collider.gameObject);
                
            }

            if (currRend == rend)
                return;

            if (currRend && currRend != rend)
            {
                if (rend)
                {
                    rend.sharedMaterial = originalMaterial;
                }

            }

            if (currRend)
                rend = currRend;
            else
                return;

            originalMaterial = rend.sharedMaterial;

            tempMaterial = new Material(originalMaterial);
            rend.material = tempMaterial;
            rend.material.color = highlightColor;

            

        }
        else
        {
            ObjectName = "";
            highlight.gameObject.SetActive(false);
            if (rend)
            {
                rend.sharedMaterial = originalMaterial;
                rend = null;
            }
        }        
    }

}
