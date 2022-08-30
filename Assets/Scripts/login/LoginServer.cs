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
public class LoginResponse
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

        // json으로 변환
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
            // 스트링으로 넘기면 json 구성이 깨지기 때문에 byte로 변환 후 파일로 업로드
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

            // json 헤더 추가
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            LoginResponse L = JsonUtility.FromJson<LoginResponse>(request.downloadHandler.text);

            // Response 시 띄울 코드 작성해야함
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError || request.isError)
            {
                Debug.Log("Error While Sending: " + request.error);
                // 로그인 실패 시 에러 창
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
                // 로그인 성공 시 창 전환 코드
                SceneManager.LoadScene("YardScene");
            }

            //request.Close();
            request.Dispose();
        }

        yield return null;
    }
}
