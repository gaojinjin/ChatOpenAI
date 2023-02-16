using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 改脚本管理聊天室的创建
/// </summary>
public class CreateChatClass : MonoBehaviour
{
    
    public TMP_InputField className;
    public Button sureBut, cancelBut;
    public GameObject createChatWindow,sendChatWindow;
    void Start()
    {
        
        sureBut.onClick.AddListener(()=> {
            //打开对话框  关闭当前窗口
            gameObject.SetActive(false);
            sendChatWindow.SetActive(true);
            MainUIManager.Instance.gameObject.SetActive(false);
        });
        cancelBut.onClick.AddListener(() => {
            //打开对话框  关闭当前窗口
            createChatWindow.SetActive(true);
            gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
