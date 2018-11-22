using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineRecipe : MonoBehaviour {
    // isi semua resep disini nanti produk diambil dari script lain (scriptable object)
    // coba pakai combineId untuk setiap item yang bisa dicombine, dibandingkan dengan memakai isCombineable
    // di script Product, pasangkan productID untuk dipanggil saat add item
    // menampung di var pertama, yang berikutnya jika var pertama != null, isi var kedua
    // if (a.combineId == b.combineId) addItem(product);

    //public Inventory inventory;
    //public InteracableObject itemFrom;
    //public InteracableObject itemTo;
    //public InteracableObject newItem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

        
	}


    // Combine algorithm masih dalam perbaikan

    //public void Combine(InteracableObject a, InteracableObject b, InteracableObject c)
    //{
    //    a = inventory.items.Find(FindItem);

    //    b = inventory.items.Find(FindItem2);
    //    if (a.isCombineable && b.isCombineable)
    //    {
    //        if (a._name == "Bola" && b._name == "Book")
    //        {
    //            Debug.Log("bikin item C");
    //        }
    //    }
        
    //}

    //public bool FindItem(InteracableObject from)
    //{

    //    return (from == itemFrom);
    //}
    //public bool FindItem2(InteracableObject to)
    //{

    //    return (to == itemTo);
    //}

}
