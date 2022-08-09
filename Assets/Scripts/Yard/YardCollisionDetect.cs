using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YardCollisionDetect : MonoBehaviour
{
    public GameObject pop; // 보여줄 팝업 창
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    void OnTriggerStay(Collider col) // 충돌 발생 시 함수 작동
    {
        //부딪힌 대상이 플레이어이고, 스페이스바를 눌렀고, 아무 팝업도 안열려있을 때 팝업 창 보여줌
        if (col.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.Space) && !P1.activeSelf && !P2.activeSelf && !P3.activeSelf && !P4.activeSelf)
            pop.SetActive(true);
    }

    void OnTriggerExit(Collider col)
    {
        // 플레이어와 충돌이 사라지면 팝업 창 사라짐
        if (col.gameObject.tag == "Player")
            pop.SetActive(false);
    }
}
