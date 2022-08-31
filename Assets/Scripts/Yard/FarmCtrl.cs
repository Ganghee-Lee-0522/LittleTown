using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//이거 안쓸 수도 있음
public class FarmCtrl : MonoBehaviour
{
    GameObject player;
    public static bool farmOk = false;//접근 했는지 안했는지 확인
    public int cropStep = 0;
    public static int selectedSeed;
    public GameObject crop;//기존 작물 이미지
    public SpriteRenderer seedlingSprite;//기존 모종 스프라이트(corp과 같음) 
    public Sprite[] TestSprite; //바뀌어질 이미지

    public GameObject pocket;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
    }

    public void PlantCrop() //주머니 선택 클릭
    {
        if(selectedSeed < 8)
        {
            crop.SetActive(true);
            Invoke("GrownCrop", 10f);
            cropStep = 1;
        }
        
    }

    public void GrownCrop()//다 자람!
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
            //충돌시
            Debug.Log("밭에 충돌");
            if (Input.GetKeyUp(KeyCode.Space))
            {              
                if(cropStep == 0)//작물이 심겨져 있지 않다면 주머니열어서 씨앗 심기
                {
                    pocket.SetActive(true);

                }else if(cropStep == 1)//작물이 자라는 중이라면 재배 할 수 없다는 팝업
                {

                }
                else if (cropStep == 2)//작물이 완벽하게 자랐다면 재배 할거냐는 팝업
                {

                }

            }
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("밭에 충돌");
    }*/
}
