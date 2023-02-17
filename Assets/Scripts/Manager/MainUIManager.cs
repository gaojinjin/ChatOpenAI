using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIManager : MonoSingleton<MainUIManager>
{
    public Button[] buts;
    public GameObject[] gos;
    public TextMeshProUGUI nameText, coinText;
    void Start()
    {
        for (int i = 0; i < buts.Length; i++)
        {
            int tempInt = i;
            buts[tempInt].onClick.AddListener(()=> {
                for (int j = 0; j < gos.Length; j++)
                {
                    gos[j].SetActive(j==tempInt);
                }
            });
        }
        UpdateData();
    }
    private void OnEnable()
    {
        UpdateData();
    }
    void UpdateData() {
        nameText.text = GameManager.Instance.Name;
        coinText.text = GameManager.Instance.Coin.ToString();
    }
}
