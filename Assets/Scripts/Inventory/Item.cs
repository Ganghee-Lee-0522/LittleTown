using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Fruit,
    Vegetable,
    Etc
}

[System.Serializable]
public class Item 
{
    
    public ItemType itemType;
    public string itemName; 
    public Sprite itemImage;



    public bool Use() 
    {
        return false;  // 사용 여부 반환을 위해 bool 반환 
    }

}

    