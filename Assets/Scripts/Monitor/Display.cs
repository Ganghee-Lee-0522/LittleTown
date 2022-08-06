using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text, Image 등의UI관련 변수 등을 사용할수 있게됩니다
 
public class Display : MonoBehaviour
{
    public Image TestImage; //기존에 존제하는 이미지
    public Sprite TestSprite; //바뀌어질 이미지
    public Text R_SeedName;
    public Text L_SeedName;
    public Text R_CoinSell;//모종 가격
    public Text R_Time;//키우는 시간
    public Text R_CoinGet;//작물 판매 가격


    public void ChangeImage()
    {
        TestImage.sprite = TestSprite; //TestImage에 SourceImage를 TestSprite에 존제하는 이미지로 바꾸어줍니다

        //함수 이름은 ChangeImage 이지만,,, 모종 가격, 키우는 시간, 작물 판매 가격 전부 할당해주자!
        R_SeedName.text = L_SeedName.text;
        
        if(L_SeedName.text == "완두콩")
        {
            R_CoinSell.text = "5";
            R_Time.text = "2";
            R_CoinGet.text = "8";
        }
        else if (L_SeedName.text == "양배추")
        {
            R_CoinSell.text = "8";
            R_Time.text = "5";
            R_CoinGet.text = "13";
        }
        else if (L_SeedName.text == "파")
        {
            R_CoinSell.text = "10";
            R_Time.text = "7";
            R_CoinGet.text = "16";
        }
        else if (L_SeedName.text == "오이")
        {
            R_CoinSell.text = "11";
            R_Time.text = "8";
            R_CoinGet.text = "17";
        }
        else if (L_SeedName.text == "가지")
        {
            R_CoinSell.text = "12";
            R_Time.text = "9";
            R_CoinGet.text = "18";
        }
        else if (L_SeedName.text == "토마토")
        {
            R_CoinSell.text = "13";
            R_Time.text = "10";
            R_CoinGet.text = "19";
        }
        else if (L_SeedName.text == "참외")
        {
            R_CoinSell.text = "16";
            R_Time.text = "13";
            R_CoinGet.text = "23";
        }
        else if (L_SeedName.text == "수박")
        {
            R_CoinSell.text = "20";
            R_Time.text = "17";
            R_CoinGet.text = "35";
        }

    }


}

