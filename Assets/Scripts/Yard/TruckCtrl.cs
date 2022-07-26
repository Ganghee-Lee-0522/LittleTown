using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckCtrl : MonoBehaviour
{
    public static bool go = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForMinute());
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
    }

    IEnumerator WaitForMinute()
    {
        yield return new WaitForSeconds(6.0f);
        go = true;
    }


}
