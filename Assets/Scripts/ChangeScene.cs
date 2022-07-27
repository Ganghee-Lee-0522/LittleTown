using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneBtn()
    {
        switch(this.gameObject.name)
        {
            case "CBtn":
                SceneManager.LoadScene("Cloth");
                break;
            case "SBtn":
                SceneManager.LoadScene("Seed");
                break;
            
        }
    }

}
