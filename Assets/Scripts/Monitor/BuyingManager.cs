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

    //���� ��ư ������ �Լ�
    public void ClickBuy()
    {
        if(int.Parse(coin.text) - int.Parse(coinSell.text) < 0)
        {
            noText.text = "������ �����մϴ�.";
            noPopup.SetActive(true);
        }else if (PocketManager.pocketNum[9]<20)//������ �ָӴϰ� ������ȣ�� ������ ������ �ָӴϴ� �� á��
        {
            noText.text = "�ָӴϰ� �� á���ϴ�.\n�ָӴϸ� ��� �� �������ּ���.";
            noPopup.SetActive(true);
        }
        else
        {
            buyPopup.SetActive(true);
        }
    }

    //���� Ȯ�� ��ư ������ �Լ�
    public void BuyYes()
    {
        Debug.Log("���� �� ������ ���� : " + PocketManager.itemNum);
        buyPopup.SetActive(false);
        buyFinishPopup.SetActive(true);

        //DB ���� ����
        DBManager.currentCoin = int.Parse(coin.text) - int.Parse(coinSell.text);
        //��ܹ� ���� ����
        coin.text = (int.Parse(coin.text) - int.Parse(coinSell.text)).ToString();

        PocketManager.pocketNum[PocketManager.itemNum] = PocketManager.sNumber;//ó������ 20�� �ָӴϿ� ������ ������ȣ�� ����
        PocketManager.itemNum++;//�ָӴϿ� �ִ� ������ ���� ���� ��Ű��

        Debug.Log("���� �� ������ ���� : " + PocketManager.itemNum);

        //PocketManager.pocketNum.Add(PocketManager.sNumber);//�ָӴϿ� ������ȣ�� ����
    }

    //���� Ȯ�� �� ���� �׸��Ѵٴ� ��ư
    public void StopShopping()
    {
        //������ �̵�
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
