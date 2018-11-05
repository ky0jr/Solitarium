using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public static Inventory instance = null;

    public List<InteracableObject> items = new List<InteracableObject>();

    public bool isInven = false;

    private void Awake()
    {
        instance = this; 
    }
    
    public void Add(InteracableObject item)
    {
        //if(!SameObject(item))
            items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public bool SameObject(InteracableObject item)
    {
        foreach(InteracableObject _item in items)
        {
            if(_item == item)
            {
                return true;
            }
        }

        return false;
    }
    public void Remove(InteracableObject item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
