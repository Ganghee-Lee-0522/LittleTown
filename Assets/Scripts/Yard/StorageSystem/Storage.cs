using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storage : MonoBehaviour
{
    //private OrderManager theOrder;

    private StorageSlot[] slots;  // 인벤토리 슬롯들 

    private List<Item> StorageItemList; // 소지 아이템 리스트 
    private List<Item> StorageTabList; // 텝 

    public Text Description_Text; // 부연설명 
    public string[] tabDescription; // 탭 부연설명 
    
    public Transform tf; //slot 부모객체 

    public GameObject go; // 활성 비활성 
    public GameObject[] selectedTabImages; // 내부 패널 
    public Text SelectedPage; 

    private int selectedItem; // 선택된 아이템
    private int selectedTab;  // 선택된 탭
 
    
    private bool activated;   // 인벤토리 활성화 시 true;
    private bool tabActivated;   // 탭  활성화 시 true;
    private bool itemActivated; // 아이템 활성화 시 true;
    // 탭이랑 아이템 이동 분리 위함 
    
    private bool stopKeyInput; // 키입력 제한  (행동 시 질의에 대한 키입력 방지)
    private bool preventExec; // 중복실행 제한 

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);


    

    private int page;
    private int slotCount; // 활성화된 슬롯 개수 
    private const int MAX_SLOTS_COUNT = 10; //슬롯 최대 개수 

    

    void Start(){
        //theOrder = FindObjectOfType<OrderManager>(); 
        StorageItemList = new List<Item>();
        StorageTabList = new List<Item>();
        slots = tf.GetComponentsInChildren<StorageSlot>(); //. slots 에 자식 객체들 할당 
        
      

        
        StorageItemList.Add(new Item(5, "토마토", "멋쟁이", Item.ItemType.fruit));
        StorageItemList.Add(new Item(6, "참외", "참 외롭다..", Item.ItemType.fruit));
        StorageItemList.Add(new Item(7, "수박", "시원한 별미", Item.ItemType.fruit));
        StorageItemList.Add(new Item(4, "가지", "싫어하는 사람도 있다", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(5, "토마토", "멋쟁이", Item.ItemType.fruit));
        StorageItemList.Add(new Item(6, "참외", "참 외롭다..", Item.ItemType.fruit));
        StorageItemList.Add(new Item(7, "수박", "시원한 별미", Item.ItemType.fruit));
        StorageItemList.Add(new Item(1, "양배추", "쌈채소",   Item.ItemType.vegetable));
        StorageItemList.Add(new Item(2, "파", "만능 요리재료", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(0, "완두콩", "귀여운 초록 콩", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(3, "오이", "싫어하는 사람이 많다", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(1, "양배추", "쌈채소",   Item.ItemType.vegetable));
        StorageItemList.Add(new Item(5, "토마토", "멋쟁이", Item.ItemType.fruit));
        StorageItemList.Add(new Item(6, "참외", "참 외롭다..", Item.ItemType.fruit));
        StorageItemList.Add(new Item(7, "수박", "시원한 별미", Item.ItemType.fruit));
        StorageItemList.Add(new Item(4, "가지", "싫어하는 사람도 있다", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(5, "토마토", "멋쟁이", Item.ItemType.fruit));
        StorageItemList.Add(new Item(6, "참외", "참 외롭다..", Item.ItemType.fruit));
        StorageItemList.Add(new Item(7, "수박", "시원한 별미", Item.ItemType.fruit));
        StorageItemList.Add(new Item(1, "양배추", "쌈채소",   Item.ItemType.vegetable));
        StorageItemList.Add(new Item(2, "파", "만능 요리재료", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(0, "완두콩", "귀여운 초록 콩", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(3, "오이", "싫어하는 사람이 많다", Item.ItemType.vegetable));
        StorageItemList.Add(new Item(3, "오이", "싫어하는 사람이 많다", Item.ItemType.vegetable));
        
        
        
        
        
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
        RemoveSlot();
        SelectedTab();
    }

   



    public void SelectedTab() // 선택한 탭 제외 다른 탭 컬러 알파값 0으로 조정 
    {
        StopAllCoroutines();
        Color color = selectedTabImages[selectedTab].GetComponent<Image>().color;
        color.a = 0f;
        for(int i = 0; i < selectedTabImages.Length; i++)   // 처음에는 둘다 0 값 
        {
            selectedTabImages[i].GetComponent<Image>().color = color; 
        }
        Description_Text.text = tabDescription[selectedTab]; // 설명 출력 
        StartCoroutine(SelectedTabEffectCoroutine());
    }










    public void ShowItem() // 아이템 활성화 , 인벤토리 탭 리스트 조건에 맞는 아이템만 넣어주고 인벤토리 슬롯에 출력 
    {
        
        StorageTabList.Clear();  
        
        RemoveSlot(); 
        selectedItem = 0;
        page = 0;

        switch(selectedTab) // 탭에 따른 아이템 분류, 그것을 탭 리스트에 추가 
        {
            case 0:
                for(int i = 0; i < StorageItemList.Count; i++)
                {
                    if(Item.ItemType.vegetable == StorageItemList[i].itemType)
                        StorageTabList.Add(StorageItemList[i]);    // vege 아이템들 탭에 들어감 
                }
                break;
            case 1:
                for(int i = 0; i < StorageItemList.Count; i++)
                {
                    if(Item.ItemType.fruit == StorageItemList[i].itemType)
                        StorageTabList.Add(StorageItemList[i]);    // fruit 아이템들 탭에 들어감 
                }
                break;  
        }

        ShowPage();


        

        SelectedItem();
        /*
        page = 0; 

        ShowPage();
        */

    }
    
    public void SelectedItem() // 아이템 
    {
        StopAllCoroutines();
        if(slotCount > -1) // 인덱스 0 일때도 취급하기 위해 -1 
        {
            
            Color color = slots[0].selected_Item.GetComponent<Image>().color;
            
            color.a = 0f; 

            for(int i = 0; i <= slotCount; i++)
                slots[i].selected_Item.GetComponent<Image>().color = color; 

            Description_Text.text = StorageTabList[selectedItem].itemDescription;
            StartCoroutine(SelectedItemEffectCoroutine());
        }
        else
            Description_Text.text = "아이템이 없습니다.";


         
    }

    public void ShowPage()
    {   
        slotCount = -1;
        SelectedPage.text = (page+1).ToString(); // 초기화가 안됨
        for(int i= page * MAX_SLOTS_COUNT; i<StorageTabList.Count; i++) // 인벤토리 탭 리스트 내용을 인벤토리 슬롯에 추가 
        {
            // 45:13 
            slotCount = i - (page * MAX_SLOTS_COUNT);  // 슬롯 개수 제한   맥스 슬롯 값 안넘어가도록
            slots[slotCount].gameObject.SetActive(true);
            slots[slotCount].Additem(StorageTabList[i]);
            
            if(slotCount == MAX_SLOTS_COUNT - 1)   // 슬롯 개수만큼 집어넣고 break 
                break; 
        }
        
    }



    IEnumerator SelectedTabEffectCoroutine()
    {
        while(tabActivated)
        {
            Color color = selectedTabImages[0].GetComponent<Image>().color; 
            while(color.a < 0.5f)
            {
                color.a += 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color; 
                yield return waitTime;
            }
            while(color.a > 0f)
            {
                color.a -= 0.03f;
                selectedTabImages[selectedTab].GetComponent<Image>().color = color; 
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f); 

        }
    }

    
    IEnumerator SelectedItemEffectCoroutine()
    {
        while(itemActivated)
        {
            Color color = slots[0].GetComponent<Image>().color; 
            while(color.a < 0.5f)
            {
                color.a += 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color; 
                yield return waitTime;
            }
            while(color.a > 0f)
            {
                color.a -= 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f); 

        }
    }





    void Update()
    {

        if(!stopKeyInput)
        {   
            

            if(Input.GetKeyDown(KeyCode.Space))              
            {
                activated = !activated;
                
                if (activated)
                {
                    //theOrder.NotMove();
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
                        color.a = 0.5f;
                        selectedTabImages[selectedTab].GetComponent<Image>().color = color;
                        itemActivated = true;
                        tabActivated = false; 
                        preventExec = true;
                        ShowItem();
                        
                    }
                    
                }
            

                else if (itemActivated) 
                {
                    if(StorageTabList.Count > 0)
                    {
                        if(Input.GetKeyDown(KeyCode.DownArrow))
                        {

                            if(selectedItem + 5 > slotCount)  // 페이지 관리 
                            {
                                if(page < (StorageTabList.Count -1)/MAX_SLOTS_COUNT)
                                    page++;
                                else 
                                    page = 0; 
                                RemoveSlot();
                                ShowPage();
                                selectedItem = -5;

                            }

                            if (selectedItem < slotCount-4) 
                                selectedItem +=5;

                            else 
                                selectedItem -=5; 

                            
                            SelectedItem();
                        }
                        
                        else if(Input.GetKeyDown(KeyCode.UpArrow))
                        {

                            if(selectedItem - 5 > 0)  // 페이지 관리 
                            {
                                if(page != 0)
                                    page--;
                                else 
                                    page = (StorageTabList.Count -1)/MAX_SLOTS_COUNT; 
                                
                                RemoveSlot();
                                ShowPage();
                                

                           }


                           
                            if(selectedItem > StorageTabList.Count-6)
                                selectedItem  -=5;
                            else 
                                selectedItem = slotCount - selectedItem; 
                            SelectedItem();
                        }


                        else if(Input.GetKeyDown(KeyCode.RightArrow))
                        {

                        if(selectedItem + 1 > slotCount)  // 페이지 관리 
                        {
                            if(page < (StorageTabList.Count -1)/MAX_SLOTS_COUNT)
                                page++;
                            else 
                                page = 0; 
                            RemoveSlot();
                            ShowPage();
                            selectedItem = -1;
                        }
                        
                        if(selectedItem < slotCount )
                            selectedItem++;  
                        else 
                            selectedItem = 0; 
                        SelectedItem();
                        }



                        else if(Input.GetKeyDown(KeyCode.LeftArrow))
                        {
                        if(selectedItem - 1 > 0)  // 페이지 관리 
                        {
                            if(page != 0)
                                page--;
                            else 
                                page = (StorageTabList.Count -1)/MAX_SLOTS_COUNT;   
                            RemoveSlot();
                            ShowPage();
                        }
                        
                        if(selectedItem > 0 )
                            selectedItem--;  
                        else 
                            selectedItem = slotCount; 
                        SelectedItem();
                        }



                        else if(Input.GetKeyDown(KeyCode.Z) && !preventExec)
                        {
                        // 아이템 사용 창 
                        // 57분 
                        }
                    }
                


            
                if(Input.GetKeyDown(KeyCode.X) && !preventExec)
                {
                    StopAllCoroutines();
                    itemActivated = false;
                    tabActivated = true;
                    ShowTab();
                }
                }
                    




                if(Input.GetKeyUp(KeyCode.Z))
                    preventExec = false;    // 중복 방지 떼는 순간 뽈스 
                
                

                
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
