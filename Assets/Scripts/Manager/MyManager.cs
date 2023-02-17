using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MyManager : MonoSingleton<MyManager>
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI icoFirstName;
    public Image vipImg;

    
    
    private void Start()
    {
        //更新初次启动 显式信息
        nameInputField.text =GameManager.Instance.Name ;
        icoFirstName.text = nameInputField.text[0].ToString();
        nameInputField.onEndEdit.AddListener((arg)=> {
            if (nameInputField.text != string.Empty)
            {
                icoFirstName.text = nameInputField.text[0].ToString();
                GameManager.Instance.Name= nameInputField.text;
                
            }
        });
    }

}
