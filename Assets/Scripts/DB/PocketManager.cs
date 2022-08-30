using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketManager : MonoBehaviour
{
    // pocket Ȱ��ȭ ���� ����
    // Ű������ "p"�� ������ pocket â�� ����
    public bool flag = false;
    public GameObject pocket;


    public List<Image> pocketImg;//�ָӴ� 1~10�� ��ġ �̹���
    public List<Sprite> itemSprite;//������ȣ ������ ������ ��������Ʈ �̹���
    public static List<int> pocketNum = new List<int>() { 20, 20, 20, 20, 20, 20, 20, 20, 20, 20 };// �ָӴ� 1~10���� �� ������ȣ(20�� ���� ������ȣ)
    public static int sNumber;//�۹�, ���� ������ȣ ���� ����
    public static int itemNum = 0;//�ָӴϿ� ��� ������ ��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // pocket â ���� �κ�
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("������ ���� : " + itemNum);
            for (int i = 0; i< itemNum; i++)
            {
                pocketImg[i].sprite = itemSprite[pocketNum[i]];
            }

            pocket.SetActive(!flag); // ���� ���̴� �����̸� �Ⱥ��̰�, �Ⱥ��̴� �����̸� ���̰� ����
            flag = !flag; // ���¸� ������Ʈ ����
        }
    }
}

/*
�۹� �� �� ������ȣ
��� 0
������ī 1
������ 2
���� 3
������ 4
�丶�� 5
���� 6
���� 7
������ ��μ�Ʈ 8
�������� ���ǽ� 9
������ ��μ�Ʈ 10
�������� ���ǽ� 11
     */
