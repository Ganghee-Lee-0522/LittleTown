using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� �ð� �� ����� invisible�ϰ� �����
// Destroy�� ������� �ϸ� �ȵǴ� ��� ����
// ������ ��� ����

public class PopUpTimer : MonoBehaviour
{  
    public GameObject gameobject; // �Ⱥ��̰� �� ����� ��Ÿ�� ����

    void Update()
    {
        Invoke("Set", 2); // 2�� �� ���������
    }

    void Set()
    {
        gameobject.SetActive(false);
    }
}
