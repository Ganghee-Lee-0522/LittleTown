using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item // 상속 없으니 삭제 
{

    public int itemID; // 아이템 고유 아이디 중복 x  & 시원 db에 있는거랑 후에 연계 
    public string itemName; // 아이템 이름, 중복 o  
    public string itemDescription; // 아이템 설명
    public int itemCount; // 소지개수 
    public Sprite itemIcon; // 아이템 아이콘 
    public ItemType itemType;
    

    public enum ItemType
    {
        vegetable,
        fruit,
        ETC
    }

    public Item(int _itemID, string _itemName, string _itemDes, ItemType _itemType, int _itemCount = 1) // 생성자 
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType; 
        itemCount = _itemCount; 
        //itemIcon = Images.Load("Resource/" +_itemID.ToString(), typeof(Sprite)) as Sprite;  // images > Item 에서 sprite  캐스팅 
        itemIcon = Resources.Load("ItemIcon/" +_itemID.ToString(), typeof(Sprite)) as Sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
