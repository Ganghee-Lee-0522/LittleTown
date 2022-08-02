using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{

    public GameObject loginCanvas;
    public GameObject registerCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void JoinSucceed()
    {
        loginCanvas.SetActive(true);
        registerCanvas.SetActive(false);
    }
    public void LoginSucceed()
    {
        SceneManager.LoadScene("YardScene");
    }
}
