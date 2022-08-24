using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;
using UnityEngine.Networking;

[System.Serializable]
public class LoginUser
{
    public string id;
    public string pw;
}

public class LoginServer : MonoBehaviour
{
    public Text inputID;
    public Text inputPw;

    void Start()
    {
        LoginUser loginuser = new LoginUser
        {
            id = inputID.GetComponent<Text>().text,
            pw = inputPw.GetComponent<Text>().text
        };

        // json으로 변환
        string json = JsonUtility.ToJson(loginuser);

        // request Post
        StartCoroutine(Upload("3.35.9.134:8080/user/login", json));
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
                
                // 로그인 실패 시 에러 창
            }
            else
            {
                Debug.Log("Received: " + request.downloadHandler.text);

                // 로그인 성공 시 창 전환 코드
            }
        }
    }
}
