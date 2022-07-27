using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    void SetVisible(GameObject image)
    {
        image.SetActive(true);
    }

    void SetInvisible()
    {
        back.SetActive(false);
        front.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
    }
}
