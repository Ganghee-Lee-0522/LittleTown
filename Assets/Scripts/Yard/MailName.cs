using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MailName : MonoBehaviour
{
    // ���� ��â���� ���� ������� ������ �̸�
    public TextMeshProUGUI who;

    public void ClickBtn()
    {
        // ���� Ŭ���� ��ư�� ���� �̸�
        GameObject click = EventSystem.current.currentSelectedGameObject;

        // ���� ��� �̸��� Ŭ���� ��ư�� ������ �̸����� �ٲ���
        who.text = click.GetComponentInChildren<TextMeshProUGUI>().text;
    }
}
