using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewChangeScene : MonoBehaviour
{
    public string sceneName; // 바꿀 씬 이름을 입력받음

    public void newCScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
