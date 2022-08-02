using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAB : MonoBehaviour
{
    public GameObject object_A1; // A ���� �� Ȱ��ȭ�� ������Ʈ ����
    public GameObject object_A2; // A ���� �� ��Ȱ��ȭ�� ������Ʈ ����
    public GameObject object_B; // B ���� �� ��Ȱ��ȭ�� ������Ʈ ����

    void Start()
    {

    }

    void Update()
    {
        // Ű������ A�� ������ ������Ʈ1 Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.A))
        {
            object_A1.SetActive(true);
            object_A2.SetActive(false);
        }

        // Ű������ B�� ������ ������Ʈ ��Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.B))
            object_B.SetActive(false);
    }
}
