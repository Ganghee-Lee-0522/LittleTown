using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuyingManager : MonoBehaviour
{
    public GameObject buyPopup;
    public GameObject noPopup;
    public GameObject buyFinishPopup;
    public Text noText;
    public Text coin;
    public Text coinSell;

    //구매 버튼 누르는 함수
    public void ClickBuy()
    {
        if(int.Parse(coin.text) - int.Parse(coinSell.text) < 0)
        {
            noText.text = "코인이 부족합니다.";
            noPopup.SetActive(true);
        }else if (PocketManager.pocketNum[9]<20)//마지막 주머니가 고유번호를 가지고 있으면 주머니는 다 찼다
        {
            noText.text = "주머니가 꽉 찼습니다.\n주머니를 비운 후 구매해주세요.";
            noPopup.SetActive(true);
        }
        else
        {
            buyPopup.SetActive(true);
        }
    }

    //구매 확정 버튼 누르는 함수
    public void BuyYes()
    {
        Debug.Log("구매 전 아이템 개수 : " + PocketManager.itemNum);
        buyPopup.SetActive(false);
        buyFinishPopup.SetActive(true);

        //DB 코인 변경
        DBManager.currentCoin = int.Parse(coin.text) - int.Parse(coinSell.text);
        //상단바 코인 변경
        coin.text = (int.Parse(coin.text) - int.Parse(coinSell.text)).ToString();

        PocketManager.pocketNum[PocketManager.itemNum] = PocketManager.sNumber;//처음으로 20인 주머니에 구매한 고유번호를 넣음
        PocketManager.itemNum++;//주머니에 있는 아이템 개수 증가 시키기

        Debug.Log("구매 후 아이템 개수 : " + PocketManager.itemNum);

        //PocketManager.pocketNum.Add(PocketManager.sNumber);//주머니에 고유번호를 넣음
    }

    //구매 확정 후 쇼핑 그만한다는 버튼
    public void StopShopping()
    {
        //방으로 이동
        SceneManager.LoadScene("SceneRoom");
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
