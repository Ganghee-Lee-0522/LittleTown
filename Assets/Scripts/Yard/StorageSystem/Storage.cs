using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storage : MonoBehaviour
{

    private StorageSlot[] slots;  // 인벤토리 슬롯들 

    private List<Item> StorageItemList; // 소지 아이템 리스트 
    private List<Item> StorageTabList; // 텝 

    public Text Description_Text; // 부연설명 
    public string[] tabDescription; // 탭 부연설명 
    
    public Transform tf; //slot 부모객체 

    public GameObject go; // 활성 비활성 
    public GameObject[] selectedTabImages; // 내부 패널 
    
    private int selectedItem; // 선택된 아이템
    private int selectedTab;  // 선택된 탭
    
    private bool activated;   // 인벤토리 활성화 시 true;
    private bool tabActivated;   // 탭  활성화 시 true;
    private bool itemActivated; // 아이템 활성화 시 true;
    // 탭이랑 아이템 이동 분리 위함 
    
    private bool stopKeyInput; // 키입력 제한  (행동 시 질의에 대한 키입력 방지)
    private bool preventExec; // 중복실행 제한 

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);


    /*

    private int page;
    private int slotCount; // 활성화된 슬롯 개수 
    private const int MAX_SLOTS_COUNT = 10; //슬롯 최대 개수 

    */

    void Start(){

        StorageItemList = new List<Item>();
        StorageTabList = new List<Item>();
        slots = tf.GetComponentsInChildren<StorageSlot>(); //. slots 에 자식 객체들 할당 
        
      

        StorageItemList.Add(new Item(1, "양배추", "쌈채소", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(2, "파", "만능 요리재료", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(0, "완두콩", "귀여운 초록 콩", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(3, "오이", "싫어하는 사람이 많다", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(4, "가지", "싫어하는 사람도 있다", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(5, "토마토", "멋쟁이", Item.ItemType.fruit));
        StorageItemList.Add(new Item(6, "참외", "참 외롭다..", Item.ItemType.fruit));
        StorageItemList.Add(new Item(7, "수박", "시원한 별미", Item.ItemType.fruit));

    
        
        
    }
    
    public void RemoveSlot() // 인벤토리 슬롯 초기화 
    {
        
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();  // StorageSlot 에 있는 함수 
            slots[i].gameObject.SetActive(false);
        }
        
    }




    public void ShowTab()   // 탭 활성화
    {
        SelectedTab();
        RemoveSlot();
    }

   



    public void SelectedTab() // 선택한 탭 제외 다른 탭 컬러 알파값 0으로 조정 
    {
        
        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
        color.a = 0f;
        for(int i = 0; i < selectedTabImages.Length; i++)
        {
            selectedTabImages[i].GetComponent<Image>().color = color; 
        }
         
        Description_Text.text = tabDescription[selectedTab];
    }

    


    public void ShowItem() // 아이템 활성화 , 인벤토리 탭 리스트 조건에 맞는 아이템만 넣어주고 인벤토리 슬롯에 출력 
    {
        
        StorageItemList.Clear(); // 
        
        RemoveSlot(); 
        selectedItem = 0;

        switch(selectedTab) // 탭에 따른 아이템 분류, 그것을 탭 리스트에 추가 
        {
            case 0:
                for(int i = 0; i < StorageItemList.Count; i++)
                {
                    if(Item.ItemType.vegetable == StorageItemList[i].itemType)
                        StorageTabList.Add(StorageItemList[i]);    // 아이템들 탭에 들어감 
                }
                break;
            case 1:
                for(int i = 0; i < StorageItemList.Count; i++)
                {
                    if(Item.ItemType.fruit == StorageItemList[i].itemType)
                        StorageTabList.Add(StorageItemList[i]);    // 아이템들 탭에 들어감 
                }
                break;  
        }
        for(int i=0; i<StorageTabList.Count; i++) // 인벤토리 탭 리스트 내용을 인벤토리 슬롯에 추가 
        {
            
            slots[i].gameObject.SetActive(true);
            slots[i].Additem(StorageTabList[i]);
            
        }

        SelectedItem();
        /*
        page = 0; 

        ShowPage();
        */

    }
    
    public void SelectedItem() // 아이템 
    {
        if(StorageItemList.Count > 0)
        {
            Color color = slots[0].selected_Item.GetComponent<Image>().color;
            color.a = 0f; 
            for(int i = 0; i<StorageTabList.Count; i++)
                slots[i].selected_Item.GetComponent<Image>().color = color; 
            Description_Text.text = StorageTabList[selectedItem].itemDescription;
        }
        else
            Description_Text.text = "아이템이 없습니다.";

    }


/*
    void ShowPage()
    {
        slotCount = 0;
        for(int i = page * MAX_SLOTS_COUNT; i < StorageItemList.Count; i++)
        {
            
            slotCount = i -(page * MAX_SLOTS_COUNT); 
            //slots[slotCount].gameObject.SetActive(true);
            slots[slotCount].Additem(StorageItemList[i]);

            if (slotCount == MAX_SLOTS_COUNT - 1)
                break;

        }
    }
  
*/

    void Update()
    {

        if(!stopKeyInput)
        {   
            

            if(Input.GetKeyDown(KeyCode.I))              
            {
                activated = !activated;
                
                if (activated)
                {
                    go.SetActive(true); // 인벤토리 활성화 
                    selectedTab = 0;   // 탭부터 고름 
                    tabActivated = true;
                    itemActivated = false;
                    ShowTab(); 
                }
                else 
                {
    
                    go.SetActive(false);
                    tabActivated = false;
                    itemActivated = false; 
                }

            }

            

            

            


            if(activated)
            {
                if(tabActivated)
                {
                    /*
                    if(Input.GetKeyDown(KeyCode.DownArrow))
                    {
                    
                    }
                    */
                    if(Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if(selectedTab < selectedTabImages.Length - 1)
                            selectedTab ++;
                        else
                            selectedTab = 0;
                        SelectedTab();
                    }

                    else if(Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if(selectedTab>0)
                            selectedTab --;
                        else
                            selectedTab =  selectedTabImages.Length - 1;
                        SelectedTab();
                    }
                    

                    if(Input.GetKeyDown(KeyCode.Z)) 
                    {
                        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
                        color.a = 0.25f;
                        selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                        itemActivated = true;
                        tabActivated = false; 
                        preventExec = true;
                        ShowItem();
                    }
                    
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



                    else if(Input.GetKeyDown(KeyCode.Z) && !preventExec)
                    {
                        // 아이템 사용 창 
                    }   

                    else if(Input.GetKeyDown(KeyCode.X) && !preventExec)
                    {
                        itemActivated = false;
                        tabActivated = true;
                        ShowTab();
                    }


                
                /*

                else if(Input.GetKeyDown(KeyCode.N))
                {
                    if (page < (StorageItemList.Count-1)/MAX_SLOTS_COUNT)
                        page ++ ; 
                    else 
                        page = 0;
                    RemoveSlot();
                    ShowPage();
                }
                */


                }
            }

            /*
            else
            {
                go.SetActive(false);
                itemActivated = false; 
        
            }
            */
        }
    }


}
