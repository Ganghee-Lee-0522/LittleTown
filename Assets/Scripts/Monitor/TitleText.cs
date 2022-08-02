using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text, Image 등의UI관련 변수 등을 사용할수 있게됩니다
 
public class TitleText : MonoBehaviour
{

    public Text O_Title;
    public Text C_Title; 
    public Text O_Description;
    public Text C_Description;


    
    public void ChangeText()
    {
        O_Title.text = C_Title.text;
        O_Description.text = C_Description.text;
    }


}

