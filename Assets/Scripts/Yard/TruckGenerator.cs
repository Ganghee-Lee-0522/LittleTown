using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckGenerator : MonoBehaviour
{

    public GameObject truckPrefab;
    public GameObject TalkCansvas;
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
        //10초가 지났고, 트럭기사와 만나지 않았다면 새로운 택배차 생성
        if (this.delta > this.span && TruckCtrl.meet == false)
        {
            this.delta = 0;
            GameObject go = Instantiate(truckPrefab) as GameObject;
            go.transform.position = new Vector3(26.5f, 2.0f, -8.0f);
            TruckCtrl.go = false;
            //택배차 만들어서 보낸 다음 집 앞에 머물 시간 새기 시작!
            StartCoroutine(WaitForMinute());
        }

        if(TruckCtrl.meet == true && TruckCtrl.start == true)
        {
            TruckCtrl.start = false;
            TalkCansvas.SetActive(true);
        }
    }

    IEnumerator WaitForMinute()
    {
        //택배차가 집 앞에 머물 시간 새기
        yield return new WaitForSeconds(6.0f);
        //택배기사를 만나지 않았다면 택배차가 그냥 가도 됨
        if(TruckCtrl.meet == false)
        {
            TruckCtrl.go = true;
        }
        
    }

    public void ByeTruck()
    {
        TruckCtrl.meet = false;
        TruckCtrl.go = true;
    }

}
