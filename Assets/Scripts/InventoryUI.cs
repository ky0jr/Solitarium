using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    [SerializeField]
    private GameObject pauseButton;

    public Transform itemsParent;

    Inventory inventory;
    
    [SerializeField]
    private GameObject invenObject;

    public InventorySlot[] slots;

    // Use this for initialization
    void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
     
	}

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void Close()
    {
        invenObject.SetActive(false);
        Inventory.instance.isInven = false;
        pauseButton.SetActive(true);
    }

    public void Open()
    {
        invenObject.SetActive(true);
        Inventory.instance.isInven = true;
        pauseButton.SetActive(false);
    }
}
