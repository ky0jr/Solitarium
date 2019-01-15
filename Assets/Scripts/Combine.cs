using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour {

    #region Singleton
    public static Combine instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]
    private GameObject InventoryPanel;
    [SerializeField]
    private GameObject CombinePanel;
    [SerializeField]
    private GameObject image;

    public bool isCombine = false;

    [SerializeField]
    private CombineSlot item01;
    [SerializeField]
    private CombineSlot item02;
    [SerializeField]
    private CombineSlot result;

    private Recipe[] recipes;

    // Use this for initialization
    void Start () {
        CombinePanel.SetActive(false);
        recipes = Resources.LoadAll<Recipe>("Recipes");
	}
	
	// Update is called once per frame
	void Update () {
		if(item01.item == null && item02.item != null)
        {
            item01.item = item02.item;
            item02.ClearSlot();
            item01.AddItem(item01.item);
        }
        if (item01.item == null || item02.item == null)
        {
            result.ClearSlot();
        }
	}

    public void CombineButton()
    {
        InventoryPanel.SetActive(!InventoryPanel.activeSelf);
        CombinePanel.SetActive(!CombinePanel.activeSelf);
        image.SetActive(!image.activeSelf);
        isCombine = !isCombine;
        AudioManager.instance.Play("ClickButton");
    }

    public void AddItem(InteractableObject item)
    {
        if(item01.item == null)
        {
            item01.AddItem(item);
        }
        else if(item02.item == null)
        {
            if (item01.item != item)
                item02.AddItem(item);
        }
        if (item01.item != null && item02.item != null)
            GetResult();
    }

    public void GetResult()
    {
        foreach(Recipe recipe in recipes)
        {
            if ((recipe.input1 == item01.item && recipe.input2 == item02.item) ||
               (recipe.input1 == item02.item && recipe.input2 == item01.item))
                result.AddItem(recipe.result);
        }
        AudioManager.instance.Play("ClickButton");
    }

    public void ClearCombine()
    {
        Inventory.instance.Remove(item01.item);
        Inventory.instance.Remove(item02.item);
        item01.ClearSlot();
        item02.ClearSlot();
        AudioManager.instance.Play("ClickButton");
    }
}
