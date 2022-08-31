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
    // ���� ��â���� ���� ������� ������ �̸�
    public Text who;
    public Text what;
    public Text user;

    public int temp = 0;

    public void ClickBtn()
    {
        // ���� Ŭ���� ��ư�� ���� �̸�
        GameObject click = EventSystem.current.currentSelectedGameObject;

        // ���� ��� �̸��� Ŭ���� ��ư�� ������ �̸����� �ٲ���
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
