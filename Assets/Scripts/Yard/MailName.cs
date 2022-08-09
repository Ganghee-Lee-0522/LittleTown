using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MailName : MonoBehaviour
{
    // 메일 상세창에서 보낸 사람으로 보여줄 이름
    public TextMeshProUGUI who;

    public void ClickBtn()
    {
        // 현재 클릭된 버튼에 쓰인 이름
        GameObject click = EventSystem.current.currentSelectedGameObject;

        // 보낸 사람 이름을 클릭된 버튼에 쓰여진 이름으로 바꿔줌
        who.text = click.GetComponentInChildren<TextMeshProUGUI>().text;
    }
}
