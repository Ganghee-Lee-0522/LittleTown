using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("농작물 저장 창고에 충돌");
    }
}
