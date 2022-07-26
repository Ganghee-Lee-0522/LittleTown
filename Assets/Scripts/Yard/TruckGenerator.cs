using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckGenerator : MonoBehaviour
{

    public GameObject truckPrefab;
    float span = 10.0f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(truckPrefab) as GameObject;
            go.transform.position = new Vector3(26.5f, 1.5f, -8.0f);
        }
    }
}
