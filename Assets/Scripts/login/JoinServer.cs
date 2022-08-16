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
        // ��й�ȣ != ��й�ȣȮ��
        // �۵� �ȵ�
        if (inputPw.GetComponent<Text>().text != inputCheckPw.GetComponent<Text>().text)
            return;

        // POST�� ����
        User testuser = new User
        {
            id = inputID.GetComponent<Text>().text,
            pw = inputPw.GetComponent<Text>().text,
            nickname = inputNick.GetComponent<Text>().text
        };

        // json���� ��ȯ
        string json = JsonUtility.ToJson(testuser);

        // request Post
        StartCoroutine(Upload("https://.../user/join", json));
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
            }
            else
            {
                Debug.Log("Received: " + request.downloadHandler.text);
            }
        }
    }
}
