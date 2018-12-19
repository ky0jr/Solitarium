using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineSlot : InventorySlot {
    public void CreateItem()
    {
        if (item != null)
        {
            Inventory.instance.Add(item);
            ClearSlot();
            Combine.instance.ClearCombine();
        }
    }
	
}
