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

        // json���� ��ȯ
        string json = JsonUtility.ToJson(loginuser);

        // request Post
        StartCoroutine(Upload("3.35.9.134:8080/user/login", json));
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

            // Response �� ��� �ڵ� �ۼ��ؾ���
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log("Error While Sending: " + request.error);
                
                // �α��� ���� �� ���� â
            }
            else
            {
                Debug.Log("Received: " + request.downloadHandler.text);

                // �α��� ���� �� â ��ȯ �ڵ�
            }
        }
    }
}
