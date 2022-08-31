using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//�̰� �Ⱦ� ���� ����
public class FarmCtrl : MonoBehaviour
{
    GameObject player;
    public static bool farmOk = false;//���� �ߴ��� ���ߴ��� Ȯ��
    public int cropStep = 0;
    public static int selectedSeed;
    public GameObject crop;//���� �۹� �̹���
    public SpriteRenderer seedlingSprite;//���� ���� ��������Ʈ(corp�� ����) 
    public Sprite[] TestSprite; //�ٲ���� �̹���

    public GameObject pocket;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
    }

    public void PlantCrop() //�ָӴ� ���� Ŭ��
    {
        if(selectedSeed < 8)
        {
            crop.SetActive(true);
            Invoke("GrownCrop", 10f);
            cropStep = 1;
        }
        
    }

    public void GrownCrop()//�� �ڶ�!
    {
        cropStep = 2;
        seedlingSprite.sprite = TestSprite[selectedSeed];
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
            //�浹��
            Debug.Log("�翡 �浹");
            if (Input.GetKeyUp(KeyCode.Space))
            {              
                if(cropStep == 0)//�۹��� �ɰ��� ���� �ʴٸ� �ָӴϿ�� ���� �ɱ�
                {
                    pocket.SetActive(true);

                }else if(cropStep == 1)//�۹��� �ڶ�� ���̶�� ��� �� �� ���ٴ� �˾�
                {

                }
                else if (cropStep == 2)//�۹��� �Ϻ��ϰ� �ڶ��ٸ� ��� �ҰųĴ� �˾�
                {

                }

            }
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�翡 �浹");
    }*/
}
