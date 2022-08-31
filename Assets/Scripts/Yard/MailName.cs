using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.EventSystems;

public class MailName : MonoBehaviour
{
    // 메일 상세창에서 보낸 사람으로 보여줄 이름
    public Text who;
    public Text what;
    public Text user;

    public int temp = 0;

    public void ClickBtn()
    {
        // 현재 클릭된 버튼에 쓰인 이름
        GameObject click = EventSystem.current.currentSelectedGameObject;

        // 보낸 사람 이름을 클릭된 버튼에 쓰여진 이름으로 바꿔줌
        who.text = click.GetComponentInChildren<Text>().text;

        for(int i = 0; i < 11; i++)
        {
            if(who.text == MailReceiveServer.sNick[i])
            {
                temp = i;
                break;
            }
        }

        what.text = MailReceiveServer.c[temp];
        user.text = MailReceiveServer.rNick[temp];
    }
}
