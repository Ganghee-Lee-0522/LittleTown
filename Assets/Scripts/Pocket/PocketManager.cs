using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketManager : MonoBehaviour
{
    // pocket 활성화 관련 변수
    // 키보드의 "p"를 누르면 pocket 창이 등장
    public bool flag = false;
    public GameObject pocket;

    //주머니 순서
    public int pocketNumber;

    public List<Image> pocketImg;//주머니 0~9번 위치 이미지
    //public static int[] pocketSNum;//주머니 0~9번 고유번호
    public List<Sprite> itemSprite;//고유번호 순으로 지정된 스프라이트 이미지
    public static List<int> pocketNum = new List<int>() { 20, 20, 20, 20, 20, 20, 20, 20, 20, 20 };// 주머니 1~10번에 들어갈 고유번호(20은 없는 고유번호)
    public static int sNumber;//작물, 옷의 고유번호 담을 변수
    public static int itemNum = 0;//주머니에 담긴 아이템 수

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // pocket 창 관련 부분
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("아이템 개수 : " + itemNum);
            for (int i = 0; i< itemNum; i++)
            {
                pocketImg[i].sprite = itemSprite[pocketNum[i]];
                //pocketSNum[i] = pocketNum[i];
            }

            pocket.SetActive(!flag); // 현재 보이는 상태이면 안보이게, 안보이는 상태이면 보이게 만듦
            flag = !flag; // 상태를 업데이트 해줌
        }
    }

    public void ClickItem()
    {
        //해당 주머니 아이템의 고유번호가 7이상일 때 옷을 바꿔줌
        if(pocketNum[pocketNumber] > 6)
        {
            DBManager.currentCloth = pocketNum[pocketNumber];
        }
        
    }
}

/*
작물 및 옷 고유번호
당근 0
파프리카 1
빨간무 2
오이 3
옥수수 4
토마토 5
참외 6
수박 7
가난한 농부수트 8
가을감자 원피스 9
부유한 농부수트 10
여름감자 원피스 11
     */
