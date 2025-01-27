using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // 플레이어 움직임 관련 변수
    public float speed = 2.0f;
    public GameObject back;
    public GameObject front;
    public GameObject left;
    public GameObject right;

    void Start()
    {
        
    }

    void Update()
    {
        // 움직임 관련 부분
        if(Input.GetKey(KeyCode.UpArrow))
        {
            SetInvisible();
            SetVisible(back);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            SetInvisible();
            SetVisible(front);
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            SetInvisible();
            SetVisible(right);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SetInvisible();
            SetVisible(left);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    // 플레이어 측면 이미지 전환 관련 부분

    // 선택 방향 이미지가 보이게 하는 함수
    void SetVisible(GameObject image)
    {
        image.SetActive(true);
    }

    // 모든 방향 이미지가 안보이게 하는 함수
    void SetInvisible()
    {
        back.SetActive(false);
        front.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
    }
}
