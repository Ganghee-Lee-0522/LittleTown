using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageCtrl : MonoBehaviour
{
    GameObject player;
    public GameObject popup;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p1 = transform.position;
        Vector3 p2 = this.player.transform.position;
        Vector3 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 2.0f;
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            //�浹��
            /*
            Debug.Log("");
            if (Input.GetKeyUp(KeyCode.Space))
            {
                popup.SetActive(true);
            }
            */
        }
    }

}
