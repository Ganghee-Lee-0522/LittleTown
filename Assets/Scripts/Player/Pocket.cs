using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    // pocket Ȱ��ȭ ���� ����
    // Ű������ "p"�� ������ pocket â�� ����
    public bool flag = false;
    public GameObject pocket;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // pocket â ���� �κ�
        if (Input.GetKeyDown(KeyCode.P))
        {
            pocket.SetActive(!flag); // ���� ���̴� �����̸� �Ⱥ��̰�, �Ⱥ��̴� �����̸� ���̰� ����
            flag = !flag; // ���¸� ������Ʈ ����
        }
    }
}
