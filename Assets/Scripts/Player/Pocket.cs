using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    // pocket 활성화 관련 변수
    // 키보드의 "p"를 누르면 pocket 창이 등장
    public bool flag = false;
    public GameObject pocket;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // pocket 창 관련 부분
        if (Input.GetKeyDown(KeyCode.P))
        {
            pocket.SetActive(!flag); // 현재 보이는 상태이면 안보이게, 안보이는 상태이면 보이게 만듦
            flag = !flag; // 상태를 업데이트 해줌
        }
    }
}
