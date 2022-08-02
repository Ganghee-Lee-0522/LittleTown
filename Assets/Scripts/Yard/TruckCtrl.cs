using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckCtrl : MonoBehaviour
{
    GameObject player;
    public static bool go = false;
    public static bool meet = false;
    public static bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
        //StartCoroutine(WaitForMinute());
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 0.0f)
        {
            transform.Translate(-0.2f, 0, 0);
        }
        
        if(go == true)
        {
            transform.Translate(-0.2f, 0, 0);
        }

        if(transform.position.x < -25.0f)
        {
            Destroy(gameObject);
            go = false;
        }

        Vector3 p1 = transform.position;
        Vector3 p2 = this.player.transform.position;
        Vector3 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 1.0f;
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            //충돌시
            Debug.Log("택배 트럭이랑 충돌");
            if (Input.GetKeyUp(KeyCode.Space))
            {
                meet = true;
                start = true;
            }
        }
    }
    /*
    IEnumerator WaitForMinute()
    {
        yield return new WaitForSeconds(6.0f);
        go = true;
    }*/



}
