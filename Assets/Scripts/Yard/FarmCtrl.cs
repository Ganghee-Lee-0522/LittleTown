using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�̰� �Ⱦ� ���� ����
public class FarmCtrl : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("potato");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 p1 = transform.position;
        Vector3 p2 = this.player.transform.position;
        Vector3 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 1.0f;
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            //�浹��
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�翡 �浹");
    }
}
