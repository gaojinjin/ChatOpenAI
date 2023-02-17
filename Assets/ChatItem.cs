using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatItem : MonoBehaviour
{
    public TextMeshProUGUI nameText, contentText;
    public void Init(SendType sendType,string contentStr) { 
        string nameStr = string.Empty;
        switch (sendType)
        {
            case SendType.User:
                nameStr = GameManager.Instance.Name[0].ToString();
                break;
            case SendType.AI:
                nameStr ="AI";
                break;
            default:
                break;
        }
        nameText.text = nameStr;
        contentText.text = contentStr;
    }
}
