using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{

    public GameObject loginCanvas;
    public GameObject registerCanvas;

    //public TextMeshProUGUI pw;
    //public TextMeshProUGUI pwre;
    public Text pw;
    public Text pwre;
    public Text pwNotice;

    // Start is called before the first frame update
    void Start()
    {
        //pw = GetComponent<TextMeshProUGUI>();
        //pwre = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (pwre.text != "")
        {
            if (pw.text == pwre.text)
            {
                pwNotice.text = "비밀번호가 일치합니다";
            }
            else
            {
                pwNotice.text = "비밀번호가 일치하지 않습니다";
            }
        }
        else
        {
            pwNotice.text = "";
        }
        /*
        if (pwre == null)
        {
            pwNotice.text = "";
        }
        else
        {
            if (pw.text == pwre.text)
            {
                pwNotice.text = "비밀번호가 일치합니다";
            }
            else
            {
                pwNotice.text = "비밀번호가 일치하지 않습니다";
            }
        }*/
    }

    public void GoRegister()
    {
        loginCanvas.SetActive(false);
        registerCanvas.SetActive(true);
    }
    public void GoLogin()
    {
        loginCanvas.SetActive(true);
        registerCanvas.SetActive(false);
    }

    /*
    public void JoinSucceed()
    {
        loginCanvas.SetActive(true);
        registerCanvas.SetActive(false);
    }
    
    public void LoginSucceed()
    {
        SceneManager.LoadScene("YardScene");
    }
    */
}
