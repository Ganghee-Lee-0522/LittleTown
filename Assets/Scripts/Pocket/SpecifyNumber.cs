using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecifyNumber : MonoBehaviour
{

    public int pocketNumber; //�ָӴ� ���� �ο�

    public void ClickItem()
    {
        DBManager.currentCloth = PocketManager.pocketNum[pocketNumber];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
