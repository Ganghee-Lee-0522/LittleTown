using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{
    public static int currentCoin = 25;//�ӽ� ���ΰ� ����, ���� ���� �� ����
    public Text coin;

    // Start is called before the first frame update
    void Start()
    {
        coin.text = currentCoin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
