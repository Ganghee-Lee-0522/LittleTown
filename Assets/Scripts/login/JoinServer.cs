using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;
using UnityEngine.Networking;
using System.Text;
using System.IO;
using System;

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

    public Text errormsg;

    public GameObject loginCanvas;
    public GameObject registerCanvas;
    public GameObject failCanvas;
    public GameObject successCanvas;

    public void JoinGame()
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
        StartCoroutine(Upload("http://3.35.9.134:8080/user/join", json));
    }

    void SetFail()
    {
        failCanvas.SetActive(false);
    }

    void SetSuccess()
    {
        successCanvas.SetActive(false);
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
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error While Sending: " + request.error);
                // �ٽ� ȸ�������� �õ��϶�� �˾� �ڵ�
                errormsg.text = L.message;
                failCanvas.SetActive(true);
                Invoke("SetFail", 2);
                request.Abort();
            }
            else
            {
                Debug.Log("Received: " + request.downloadHandler.text);
                loginCanvas.SetActive(true);
                registerCanvas.SetActive(false);
                // ȸ������ ���� �˾� �ڵ�
                successCanvas.SetActive(true);
                Invoke("SetSuccess", 2);

            }

            //request.Close();            
            request.Dispose();            
        }

        yield return null;

        /*
        HttpWebRequest request = null;
        HttpWebResponse response = null;

        try
        {
            byte[] bytes = UTF8Encoding.UTF8.GetBytes(json);
            request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = 1000;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
                stream.Close();
            }

            response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string myjson = reader.ReadToEnd();
            Debug.Log("Received: " + response);

            return null;
        }
        catch(WebException webExcp)
        {
            WebExceptionStatus status = webExcp.Status;
            if (status == WebExceptionStatus.ProtocolError)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
            }
            return null;
        }
        catch(Exception e)
        {
            throw e;
            return null;
        }

        response.Close();
        response.Dispose();
        request.Abort();
        */

        /*
        byte[] jsonToSend = Encoding.UTF8.GetBytes(json);
        UnityWebRequest webRequest = new(URL, "POST");
        webRequest.uploadHandler = new UploadHandlerRaw(jsonToSend);
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();
        switch(webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError("Error: " + webRequest.error);
                loginCanvas.SetActive(true);
                registerCanvas.SetActive(false);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.Log("Received: " + webRequest.downloadHandler.text);
                loginCanvas.SetActive(true);
                registerCanvas.SetActive(false);
                break;
            default:
                Debug.Log("\n" + webRequest.result);
                loginCanvas.SetActive(true);
                registerCanvas.SetActive(false);
                break;
        }

        webRequest.Dispose();
        */

    }
}
