using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A, B 둘 다 새로운 기능을 지칭할 때 사용할 스크립트
// 기존 스크립트는 A 기능만 사용, B는 단순 종료임
public class newPressAB : MonoBehaviour
{
    public GameObject object_A1; // A 누를 때 활성화할 오브젝트 지정
    public GameObject object_A2; // A 누를 때 비활성화할 오브젝트 지정
    public GameObject object_B1; // B 누를 때 활성화할 오브젝트 지정
    public GameObject object_B2; // B 누를 때 비활성화할 오브젝트 지정

    void Start()
    {

    }

    void Update()
    {
        // 키보드의 A를 누르면 오브젝트A1 활성화, A2 종료
        if (Input.GetKeyDown(KeyCode.A))
        {
            object_A1.SetActive(true);
            object_A2.SetActive(false);
        }

        // 키보드의 B를 누르면 오브젝트B1 활성화, B2 종료
        if (Input.GetKeyDown(KeyCode.B))
        {
            object_B1.SetActive(true);
            object_B2.SetActive(false);
        }
    }
}
