using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Inventory : MonoBehaviour
{

    // 오디오 넣을 수 있음! 
    // 카테고리 분류 가능! 
    // private OrderManager theOrder; 
    private InventorySlot[] slots;  // 인벤토리 슬롯들 

    private List<Item> inventoryItemList; // 소지 아이템 리스트 
    private List<Item> inventoryTabList; // 텝 

    public Text Description_Text; // 부연설명 
    
    public Transform tf; //slot 부모객체 

    public GameObject go;
    public GameObject[] selectedTabImages; // 내부 패널 

    private int selectedItem;
    private int selectedTab; // 선택된 아이템 
    
    private bool activated;   // 인벤토리 활성화 시 true;
    private bool tabActivated;   // 탭  활성화 시 true;
    private bool itemActivated; // 아이템 활성화 시 true;
    private bool stopKeyInput; // 키입력 제한  (행동 시 질의에 대한 키입력 방지)
    private bool preventExec; // 중복실행 제한 


    private int page;
    private int slotCount; // 활성화된 슬롯 개수 
    private const int MAX_SLOTS_COUNT = 10; //슬롯 최대 개수 




    //private WaitForSeconds waitTime = new WaitForSeconds(0.01f); 

    

    void Start(){
        inventoryItemList = new List<Item>();
        inventoryTabList = new List<Item>();
        slots = tf.GetComponentsInChildren<InventorySlot>(); // slots 에 자식 객체들 할당 
    
        inventoryItemList.Add(new Item(0, "완두콩", "귀여운 초록 콩", Item.ItemType.vegetable));
        inventoryItemList.Add(new Item(1, "양배추", "쌈채소", Item.ItemType.vegetable));
        inventoryItemList.Add(new Item(2, "파", "만능 요리재료", Item.ItemType.vegetable));
        inventoryItemList.Add(new Item(3, "오이", "싫어하는 사람이 많다", Item.ItemType.vegetable));
        inventoryItemList.Add(new Item(4, "가지", "싫어하는 사람도 있다", Item.ItemType.vegetable));
        inventoryItemList.Add(new Item(5, "토마토", "멋쟁이", Item.ItemType.fruit));
        inventoryItemList.Add(new Item(6, "참외", "참 외롭다..", Item.ItemType.fruit));
        inventoryItemList.Add(new Item(7, "수박", "시원한 별미", Item.ItemType.fruit));
        inventoryItemList.Add(new Item(0, "완두콩", "귀여운 초록 콩", Item.ItemType.vegetable));
        inventoryItemList.Add(new Item(1, "양배추", "쌈채소", Item.ItemType.vegetable));
        inventoryItemList.Add(new Item(2, "파", "만능 요리재료", Item.ItemType.vegetable));
        inventoryItemList.Add(new Item(3, "오이", "싫어하는 사람이 많다", Item.ItemType.vegetable));
        inventoryItemList.Add(new Item(4, "가지", "싫어하는 사람도 있다", Item.ItemType.vegetable));
        inventoryItemList.Add(new Item(5, "토마토", "멋쟁이", Item.ItemType.fruit));
        inventoryItemList.Add(new Item(6, "참외", "참 외롭다..", Item.ItemType.fruit));
        inventoryItemList.Add(new Item(7, "수박", "시원한 별미", Item.ItemType.fruit));
        
        
    }



/*
    public void ShowTab()   // 탭 활성화
    {
        SelectedTab();
        RemoveSlot();
    }

*/



     public void RemoveSlot()  // 인벤토리 슬롯 초기화 
    {
        for(int i = 0; i < slots.Length; i++)
        {
            
            slots[i].gameObject.SetActive(false); 
            slots[i].RemoveItem();
        }
    }

    public void SelectedTab()
    {

    }

    



    public void ShowItem() // 아이템 활성화 
    {
        
        

        //inventoryItemList.Clear(); // 
        
        //RemoveSlot(); 
        

/*
        for(int i = 0; i < inventoryItemList.Count; i++)
        {
            inventoryTabList.Add(inventoryItemList[i]);    // 아이템들 탭에 들어감 
        }
        break; 
        

        for(int i=0; i<inventoryTabList.Count; i++) // 인벤토리 탭 리스트 내용을 인벤토리 슬롯에 추가 
        {
            
            slots[i].gameObject();
            slots[i].Additem(inventoryTabList[i]);
            

            //slots[i].gameObject();
            slots[i].Additem(inventoryItemList[i]);
        }
*/
        selectedItem = 0;

        page = 0; 

        ShowPage();

    }


    void ShowPage()
    {
        slotCount = 0;
        for(int i = page * MAX_SLOTS_COUNT; i < inventoryItemList.Count; i++)
        {
            
            slotCount = i -(page * MAX_SLOTS_COUNT); 
            //slots[slotCount].gameObject.SetActive(true);
            slots[slotCount].Additem(inventoryItemList[i]);

            if (slotCount == MAX_SLOTS_COUNT - 1)
                break;

        }
    }
    
    void Update()
    {

        if(!stopKeyInput)
        {
            if(Input.GetKeyDown(KeyCode.I))  // I 누르면 켜짐 후에 수정
            {
                activated = ! activated;
                
                go.SetActive(true);
                tabActivated = true;
                selectedTab = 0;
                tabActivated = true;
                itemActivated = true;
                //ShowTab(); 
                ShowItem();


            }

            else if (itemActivated) 
            {
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    selectedItem +=5;
                }
                else if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    selectedItem -=5;
                }
                else if(Input.GetKeyDown(KeyCode.RightArrow))
                {
                    selectedItem +=1;
                }
                else if(Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    selectedItem -=1;
                }





                else if(Input.GetKeyDown(KeyCode.N))
                {
                    if (page < (inventoryItemList.Count-1)/MAX_SLOTS_COUNT)
                        page ++ ; 
                    else 
                        page = 0;
                    RemoveSlot();
                    ShowPage();
                }
                


            }
            


            else
            {
                go.SetActive(false);
                itemActivated = false; 
                
            }
        }
    }


}
