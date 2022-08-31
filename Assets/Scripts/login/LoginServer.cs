using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.IO;

[System.Serializable]
public class LoginUser
{
    public string id;
    public string pw;
}

[System.Serializable]
public class LoginData
{
    public int userIdx;
    public int clothIdx;
    public int money;
}

[System.Serializable]
public class CommonResponse
{
    public string status;
    public string message;
    public LoginData data;
}

public class LoginServer : MonoBehaviour
{
    public static int userIndex;
    public static int clothIndex;
    
    public Text inputID;
    public Text inputPw;

    public Text errormsg;

    public GameObject failCanvas;

    public void LoginGame()
    {
        LoginUser loginuser = new LoginUser
        {
            id = inputID.GetComponent<Text>().text,
            pw = inputPw.GetComponent<Text>().text
        };

        // json���� ��ȯ
        string json = JsonUtility.ToJson(loginuser);

        // request Post
        StartCoroutine(Upload("http://3.35.9.134:8080/user/login", json));
    }

    void SetFail()
    {
        failCanvas.SetActive(false);
    }

    IEnumerator Upload(string URL, string json)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(URL, json))
        {
            // ��Ʈ������ �ѱ�� json ������ ������ ������ byte�� ��ȯ �� ���Ϸ� ���ε�
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

            // json ��� �߰�
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            CommonResponse L = JsonUtility.FromJson<CommonResponse>(request.downloadHandler.text);

            // Response �� ��� �ڵ� �ۼ��ؾ���
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError || request.isNetworkError)
            {
                Debug.Log("Error While Sending: " + request.error);
                // �α��� ���� �� ���� â
                errormsg.text = L.message;
                failCanvas.SetActive(true);
                Invoke("SetFail", 2);
                request.Abort();
            }
            else
            {
                Debug.Log("Received: " + request.downloadHandler.text);
                userIndex = L.data.userIdx;
                clothIndex = L.data.clothIdx;
                DBManager.currentCoin = L.data.money;
                // �α��� ���� �� â ��ȯ �ڵ�
                SceneManager.LoadScene("SceneRoom");
                //시연을 위한 코인 조작 코드
                DBManager.currentCoin = 200;
            }

            //request.Close();
            request.Dispose();
        }

        yield return null;
    }
}
