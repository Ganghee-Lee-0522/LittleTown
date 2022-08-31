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
public class MailForm
{
    public int sender;
    public string receiverName;
    public string contents;
}

public class MailWriteServer : MonoBehaviour
{
    public Text inputReceiver;
    public Text inputContents;

    public GameObject failCanvas;
    public GameObject successCanvas;
    public GameObject thisCanvas;

    public GameObject holder1;
    public GameObject holder2;

    public Text errormsg;

    public void MailWrite()
    {
        MailForm mailform = new MailForm
        {
            sender = LoginServer.userIndex,
            receiverName = inputReceiver.GetComponent<Text>().text,
            contents = inputContents.GetComponent<Text>().text
        };

        inputReceiver.text = null;
        inputContents.text = null;
        holder1.SetActive(true);
        holder2.SetActive(true);

        // json���� ��ȯ
        string json = JsonUtility.ToJson(mailform);

        // request Post
        StartCoroutine(Upload("http://3.35.9.134:8080/email/write", json));
    }

    void SetFail()
    {
        failCanvas.SetActive(false);
    }

    void SetSuccess()
    {
        successCanvas.SetActive(false);
        thisCanvas.SetActive(false);
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
                // ���� ���� ���� �� ���� â
                errormsg.text = L.message;
                failCanvas.SetActive(true);
                Invoke("SetFail", 2);
                request.Abort();
            }
            else
            {
                Debug.Log("Received: " + request.downloadHandler.text);
                // ���� ���� ���� �� â ��ȯ �ڵ�
                successCanvas.SetActive(true);
                Invoke("SetSuccess", 2);
            }

            //request.Close();
            request.Dispose();
        }

        yield return null;
    }
}
