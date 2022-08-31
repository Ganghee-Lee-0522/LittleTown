using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBManager : MonoBehaviour
{
    public static int currentCoin = 100;//임시 코인값 설정, 데베 연결 후 변경
    public Text coin;
    public static int currentCloth = 8;
    public static int selectedSeed;

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
