using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YardCollisionDetect : MonoBehaviour
{
    public GameObject pop; // ������ �˾� â
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;

    void OnTriggerStay(Collider col) // �浹 �߻� �� �Լ� �۵�
    {
        //�ε��� ����� �÷��̾��̰�, �����̽��ٸ� ������, �ƹ� �˾��� �ȿ������� �� �˾� â ������
        if (col.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.Space) && !P1.activeSelf && !P2.activeSelf && !P3.activeSelf && !P4.activeSelf)
            pop.SetActive(true);
    }

    void OnTriggerExit(Collider col)
    {
        // �÷��̾�� �浹�� ������� �˾� â �����
        if (col.gameObject.tag == "Player")
            pop.SetActive(false);
    }
}
