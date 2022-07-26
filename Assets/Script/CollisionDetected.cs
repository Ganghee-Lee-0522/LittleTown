using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetected : MonoBehaviour
{
    public GameObject pop; // 보여줄 팝업 창

    void OnTriggerStay(Collider col) // 충돌 발생 시 함수 작동
    {
        //부딪힌 대상이 플레이어이고, 스페이스바를 눌렀다면 팝업 창 보여줌
        if (col.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.Space))
            pop.SetActive(true);
    }

    void OnTriggerExit(Collider col)
    {
        // 플레이어와 충돌이 사라지면 팝업 창 사라짐
        if (col.gameObject.tag == "Player")
            pop.SetActive(false);
    }
}
