using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일정 시간 후 대상을 invisible하게 만든다
// Destroy로 사라지게 하면 안되는 대상에 적용
// 재사용할 대상에 적용

public class PopUpTimer : MonoBehaviour
{  
    public GameObject gameobject; // 안보이게 할 대상을 나타낼 변수

    void Update()
    {
        Invoke("Set", 2); // 2초 뒤 사라지도록
    }

    void Set()
    {
        gameobject.SetActive(false);
    }
}
