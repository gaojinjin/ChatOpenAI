using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoSingleton<MainUIManager>
{
    public Button[] buts;
    public GameObject[] gos;

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
                gameObject.SetActive(tempInt != 0);
            });
        }
    }

    
}
