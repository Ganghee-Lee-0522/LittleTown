using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAB : MonoBehaviour
{
    public GameObject object_A1; // A 누를 때 활성화할 오브젝트 지정
    public GameObject object_A2; // A 누를 때 비활성화할 오브젝트 지정
    public GameObject object_B; // B 누를 때 비활성화할 오브젝트 지정

    void Start()
    {

    }

    void Update()
    {
        // 키보드의 A를 누르면 오브젝트1 활성화
        if (Input.GetKeyDown(KeyCode.A))
        {
            object_A1.SetActive(true);
            object_A2.SetActive(false);
        }

        // 키보드의 B를 누르면 오브젝트 비활성화
        if (Input.GetKeyDown(KeyCode.B))
            object_B.SetActive(false);
    }
}
