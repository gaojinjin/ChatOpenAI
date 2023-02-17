using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MessageManager : MonoSingleton<MessageManager>
{
    public Button sureBut;
    public TextMeshProUGUI messageText;
    void Start()
    {
        gameObject.SetActive(false);
        sureBut.onClick.AddListener(()=> {
            gameObject.SetActive(false);
        });
    }

    public void Show(string message) {
        gameObject.SetActive(true);
        messageText.text = message;
    }
}
