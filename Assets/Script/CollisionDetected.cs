using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetected : MonoBehaviour
{
    public GameObject pop; // ������ �˾� â

    void OnTriggerStay(Collider col) // �浹 �߻� �� �Լ� �۵�
    {
        //�ε��� ����� �÷��̾��̰�, �����̽��ٸ� �����ٸ� �˾� â ������
        if (col.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.Space))
            pop.SetActive(true);
    }

    void OnTriggerExit(Collider col)
    {
        // �÷��̾�� �浹�� ������� �˾� â �����
        if (col.gameObject.tag == "Player")
            pop.SetActive(false);
    }
}
