using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothDisplay : MonoBehaviour
{
    public Image TestImage; //기존에 존제하는 이미지
    public Sprite TestSprite; //바뀌어질 이미지
    public Text R_ClothName;
    public Text L_ClothName;
    public Text R_CoinSell;//옷 가격

    public void ChangePanel()
    {
        TestImage.sprite = TestSprite; //TestImage에 SourceImage를 TestSprite에 존제하는 이미지로 바꾸어줍니다

        R_ClothName.text = L_ClothName.text;

        if (L_ClothName.text == "옷1")
        {
            R_CoinSell.text = "5";
            PocketManager.sNumber = 8;
        }
        else if (L_ClothName.text == "옷2")
        {
            R_CoinSell.text = "8";
            PocketManager.sNumber = 9;
        }
        else if (L_ClothName.text == "옷3")
        {
            R_CoinSell.text = "10";
            PocketManager.sNumber = 10;
        }
        else if (L_ClothName.text == "옷4")
        {
            R_CoinSell.text = "11";
            PocketManager.sNumber = 1;
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
