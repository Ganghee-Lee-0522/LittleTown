using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A, B �� �� ���ο� ����� ��Ī�� �� ����� ��ũ��Ʈ
// ���� ��ũ��Ʈ�� A ��ɸ� ���, B�� �ܼ� ������
public class newPressAB : MonoBehaviour
{
    public GameObject object_A1; // A ���� �� Ȱ��ȭ�� ������Ʈ ����
    public GameObject object_A2; // A ���� �� ��Ȱ��ȭ�� ������Ʈ ����
    public GameObject object_B1; // B ���� �� Ȱ��ȭ�� ������Ʈ ����
    public GameObject object_B2; // B ���� �� ��Ȱ��ȭ�� ������Ʈ ����

    void Start()
    {

    }

    void Update()
    {
        // Ű������ A�� ������ ������ƮA1 Ȱ��ȭ, A2 ����
        if (Input.GetKeyDown(KeyCode.A))
        {
            object_A1.SetActive(true);
            object_A2.SetActive(false);
        }

        // Ű������ B�� ������ ������ƮB1 Ȱ��ȭ, B2 ����
        if (Input.GetKeyDown(KeyCode.B))
        {
            object_B1.SetActive(true);
            object_B2.SetActive(false);
        }
    }
}
