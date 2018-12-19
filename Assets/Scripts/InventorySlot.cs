using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public InteractableObject item;

    public Image icon;

    public Image bigIcon;

    public Text text;

    public void AddItem(InteractableObject newItem)
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

    public void OnButton()
    {
        if (item == null)
            return;
        if (!Combine.instance.isCombine)
        {
            bigIcon.sprite = item.icon;
            text.text = item.description;
        }
        else
            Combine.instance.AddItem(item);
    }

}
