using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public Button loadBut;
    void Start()
    {
        loadBut.onClick.AddListener(()=> {

            SceneManager.LoadScene(1);  
        });
        
    }

    
}
