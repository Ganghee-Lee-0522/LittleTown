using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageCtrl : MonoBehaviour
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
        float r1 = 2.0f;
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            //충돌시
            Debug.Log("농작물 저장 창고에 충돌");
            if (Input.GetKeyUp(KeyCode.Space))
            {

            }
        }
    }

}
