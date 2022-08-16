using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;
using UnityEngine.Networking;

[System.Serializable]
public class User
{
    public string id;
    public string pw;
    public string nickname;
}

public class JoinServer : MonoBehaviour
{
    public Text inputID;
    public Text inputPw;
    public Text inputCheckPw;
    public Text inputNick;

    void JoinGame()
    {
        // 비밀번호 != 비밀번호확인
        // 작동 안됨
        if (inputPw.GetComponent<Text>().text != inputCheckPw.GetComponent<Text>().text)
            return;

        // POST할 정보
        User testuser = new User
        {
            id = inputID.GetComponent<Text>().text,
            pw = inputPw.GetComponent<Text>().text,
            nickname = inputNick.GetComponent<Text>().text
        };

        // json으로 변환
        string json = JsonUtility.ToJson(testuser);

        // request Post
        StartCoroutine(Upload("https://.../user/join", json));
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

            // Response 시 띄울 코드 작성해야함
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log("Error While Sending: " + request.error);
            }
            else
            {
                Debug.Log("Received: " + request.downloadHandler.text);
            }
        }
    }
}
