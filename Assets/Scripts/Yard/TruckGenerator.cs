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
        //10�ʰ� ������, Ʈ������ ������ �ʾҴٸ� ���ο� �ù��� ����
        if (this.delta > this.span && TruckCtrl.meet == false)
        {
            this.delta = 0;
            GameObject go = Instantiate(truckPrefab) as GameObject;
            go.transform.position = new Vector3(26.5f, 2.0f, -8.0f);
            TruckCtrl.go = false;
            //�ù��� ���� ���� ���� �� �տ� �ӹ� �ð� ���� ����!
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
        //�ù����� �� �տ� �ӹ� �ð� ����
        yield return new WaitForSeconds(6.0f);
        //�ù��縦 ������ �ʾҴٸ� �ù����� �׳� ���� ��
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
