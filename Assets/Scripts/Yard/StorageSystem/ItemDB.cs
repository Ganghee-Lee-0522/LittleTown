using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public List<Item> itemList = new List<Item>();

    void Start(){
        itemList.Add(new Item(0, "완두콩", "귀여운 초록 콩", Item.ItemType.vegetable));
        itemList.Add(new Item(1, "양배추", "쌈채소", Item.ItemType.vegetable));
        itemList.Add(new Item(2, "파", "만능 요리재료", Item.ItemType.vegetable));
        itemList.Add(new Item(3, "오이", "싫어하는 사람이 많다", Item.ItemType.vegetable));
        itemList.Add(new Item(4, "가지", "싫어하는 사람도 있다", Item.ItemType.vegetable));
        itemList.Add(new Item(5, "토마토", "멋쟁이", Item.ItemType.fruit));
        itemList.Add(new Item(6, "참외", "참 외롭다..", Item.ItemType.fruit));
        itemList.Add(new Item(7, "수박", "시원한 별미", Item.ItemType.fruit));
    }    
}
