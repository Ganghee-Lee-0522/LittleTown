using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StorageSlot : MonoBehaviour
{
    public Image icon;
    public Text itemCount_Text; 
    public Text itemName_Text; 
    public GameObject selected_Item;
    
    public void Additem(Item _item)
    {
        
        itemName_Text.text = _item.itemName; // _item 은 넘어온 parameter
        icon.sprite = _item.itemIcon;
        
        
        if(_item.itemCount > 0)
            itemCount_Text.text = "x " + _item.itemCount.ToString(); // 한개 이상이면 x n개 
        else
            itemCount_Text.text = "";    // 없으면 안뜸 
         
    }

    public void RemoveItem()
    {
        itemName_Text.text = "";
        itemCount_Text.text = "";
        icon.sprite = null;
    }
    
}

//13 46