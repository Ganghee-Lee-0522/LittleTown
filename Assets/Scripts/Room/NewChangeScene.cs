using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewChangeScene : MonoBehaviour
{
    public string sceneName; // �ٲ� �� �̸��� �Է¹���

    public void newCScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
