using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//이거 안쓸 수도 있음
public class FarmCtrl : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 p1 = transform.position;
        Vector3 p2 = this.player.transform.position;
        Vector3 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 1.3f;
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            //충돌시
            Debug.Log("밭에 충돌");
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //작물이 완벽하게 자랐다면 재배 할거냐는 팝업
                //작물이 자라는 중이라면 재배 할 수 없다는 팝업
                //작물이 심겨져 있지 않다면 주머니열어서 씨앗 심기
            }
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("밭에 충돌");
    }*/
}
