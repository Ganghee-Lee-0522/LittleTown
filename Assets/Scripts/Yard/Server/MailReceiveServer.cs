using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

[System.Serializable]
public class MailResponse
{
    public string receiverNickname;
    public string senderNickname;
    public string contents;
}

[System.Serializable]
public class MailList
{
    public MailResponse[] emailList;
}

[System.Serializable]
public class OnlyMailResponse
{
    public string status;
    public string message;
    public MailList data;
}

public class MailReceiveServer : MonoBehaviour
{
    public Text[] M;
    public GameObject[] O;

    public static string[] rNick;
    public static string[] sNick;
    public static string[] c;
    
    public void ReceiveMail()
    {
        string key = "" + LoginServer.userIndex;
        string mailurl = "http://3.35.9.134:8080/email/list/" + key;
        Debug.Log(mailurl);
        StartCoroutine(Download(mailurl));
    }

    IEnumerator Download(string URL)
    {
        Debug.Log("---------- GET Request Start ----------");

        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            yield return request.SendWebRequest(); // ������ ���� ������ ���

            Debug.Log(request.downloadHandler.text);
            //Dictionary<string, object> response = Json.Deserialize(request.downloadHandler.text) as Dictionary<string, object>;
            //Debug.Log(response["data.emailList"]);
            OnlyMailResponse L = JsonUtility.FromJson<OnlyMailResponse>(request.downloadHandler.text);

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError || request.isNetworkError)
            {
                Debug.Log("Error While Sending: " + request.error);
            }
            else
            {
                Debug.Log("Received: " + request.downloadHandler.text);
                for(int i = 0; L.data.emailList[i] != null; i++)
                {
                    Debug.Log(i + "=================");
                    O[i].SetActive(true);
                    M[i].text = L.data.emailList[i].senderNickname;
                    Debug.Log(M[i]);
                    rNick[i] = L.data.emailList[i].receiverNickname;
                    sNick[i] = L.data.emailList[i].senderNickname;
                    c[i] = L.data.emailList[i].contents;
                }
                /*
                foreach (MailResponse r in L.data.emailList)
                {
                    Debug.Log(i + "=================");
                    O[i].SetActive(true);
                    M[i].text = r.senderNickname;
                    Debug.Log(M[i]);
                    rNick[i] = r.receiverNickname;
                    sNick[i] = r.senderNickname;
                    c[i] = r.contents;
                    i++;
                }
                */
            }
            request.Dispose();
        }
        yield return null;
    }
}
