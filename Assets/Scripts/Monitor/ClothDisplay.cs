using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothDisplay : MonoBehaviour
{
    public Image TestImage; //������ �����ϴ� �̹���
    public Sprite TestSprite; //�ٲ���� �̹���
    public Text R_ClothName;
    public Text L_ClothName;
    public Text R_CoinSell;//�� ����

    public void ChangePanel()
    {
        TestImage.sprite = TestSprite; //TestImage�� SourceImage�� TestSprite�� �����ϴ� �̹����� �ٲپ��ݴϴ�

        R_ClothName.text = L_ClothName.text;

        if (L_ClothName.text == "������ ��μ�Ʈ")
        {
            R_CoinSell.text = "80";
            PocketManager.sNumber = 8;
        }
        else if (L_ClothName.text == "�������� ���ǽ�")
        {
            R_CoinSell.text = "95";
            PocketManager.sNumber = 9;
        }
        else if (L_ClothName.text == "������ ��μ�Ʈ")
        {
            R_CoinSell.text = "120";
            PocketManager.sNumber = 10;
        }
        else if (L_ClothName.text == "�������� ���ǽ�")
        {
            R_CoinSell.text = "150";
            PocketManager.sNumber = 11;
        }
        

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
