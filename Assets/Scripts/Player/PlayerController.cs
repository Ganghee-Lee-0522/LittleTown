using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigid;
    Animator animator;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            this.animator.SetTrigger("BackTrigger");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            this.animator.SetTrigger("FrontTrigger");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            this.animator.SetTrigger("RightTrigger");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            this.animator.SetTrigger("LeftTrigger");
        }

    }
}
