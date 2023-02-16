using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class GameManager : MonoSingleton<GameManager>
{
    public Data data = new Data();
    private string filePath;
    public TextAsset file;

    private void Start()
    {
        string fileData = string.Empty;
        if (!File.Exists(filePath))
        {
            fileData = file.text;
        }
        else
        {
            filePath = Application.persistentDataPath + "Data.kiwi";
            FileStream fs = new FileStream(filePath,FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            fileData = sr.ReadToEnd();
            sr.Close();
            fs.Close();
        }
        data = JsonUtility.FromJson<Data>(fileData);

    }
    /// <summary>
    /// 存储文件到沙盒
    /// </summary>
    public void Save() {
        FileStream fs = new FileStream(Application.persistentDataPath + "Data.kiwi", FileMode.Open);
        StreamWriter sr = new StreamWriter(fs);
        sr.Write(JsonUtility.ToJson(data));
        sr.Close();
        fs.Close();
    }
    /// <summary>
    /// 退出场景的时候保存内容
    /// </summary>
    private void OnDestroy()
    {
        Save();
    }

}
[Serializable]
public class Data {
    public User user;
    public Shops shop;
}
[Serializable]
public class User {
    public string name;
    public int coin;
}
[Serializable]
public class Shops {
    public Shop[] shop;
}
[Serializable]
public class Shop {
    public string name, description, icoName;
    public int expend;
}