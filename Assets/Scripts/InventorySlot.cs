using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    InteracableObject item;

    public Image icon;

    public Image bigIcon;

    public Text text;

    public void AddItem(InteracableObject newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void ShowItemDescription()
    {
        if (item == null)
            return;
        bigIcon.sprite = item.icon;
        text.text = item.description;
    }

}
