using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;
using System.Linq;
using Cysharp.Threading.Tasks;
using TMPro;

public class ChatGPTManager : MonoSingleton<ChatGPTManager>
{

    public Button createChatBut, chatHistoryBut;
    public GameObject chatWindow, createChatGo, chatHistroyGo;

    /// <summary>
    /// API端点
    /// </summary>
    const string API_END_POINT = "https://api.openai.com/v1/completions";
    //const string API_END_POINT = "https://api.openai.com/v1/completions";
    /// <summary>
    /// API KEY
    /// </summary>
    const string API_KEY = "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";
    /// <summary>
    /// 输入框
    /// </summary>
    [SerializeField]
    private TMP_InputField Input;
    [SerializeField]
    private TMP_Text Output;

    [SerializeField]
    private Button ExecButton;
    [SerializeField]
    private Button BackButton;

    
    public Transform childPar;
    

    
    private void Start()
    {
        //注册按钮事件
        createChatBut.onClick.AddListener(()=> {
            //隐藏部分组件  显式创建聊天空
            chatWindow.SetActive(false);
            createChatGo.SetActive(false);
        });


        // API执行按钮
        ExecButton.onClick.AddListener(async () =>
        {
            //获取输入内容
            string prompt = Input.text;
            if (!string.IsNullOrEmpty(prompt))
            {
                //获取回调内容
                var response = await GetAPIResponse(prompt);
                //从回复文本内容获取文本内容
                string outputText = response.Choices.FirstOrDefault().Text;
                Transform textItem = Instantiate(Output.transform, childPar);
                textItem.GetComponent<TMP_Text>().text = outputText.TrimStart('\n');
                Debug.Log(outputText);
            }

        });
        // 关闭当前页面显示
        BackButton.onClick.AddListener(() =>
        {
            chatHistroyGo.SetActive(false);
            MainUIManager.Instance.gameObject.SetActive(true);
        });
    }

    /// <summary>
    /// API相应获取内容
    /// </summary>
    /// <param name="prompt"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async UniTask<APIResponseData> GetAPIResponse(string prompt)
    {

        APIRequestData requestData = new APIRequestData()
        {
            Prompt = prompt,
            MaxTokens = 300 //如果响应文本中断，改变这里
        };

        string requestJson = JsonConvert.SerializeObject(requestData, Formatting.Indented);
        Debug.Log(requestJson);

        // POST发送数据
        byte[] data = System.Text.Encoding.UTF8.GetBytes(requestJson);


        string jsonString = null;
        // POST发送请求
        using (UnityWebRequest request = UnityWebRequest.Post(API_END_POINT, "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(data);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "Bearer " + API_KEY);
            await request.SendWebRequest();

            switch (request.result)
            {
                case UnityWebRequest.Result.InProgress:
                    Debug.Log("请求中");
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("请求成功");
                    jsonString = request.downloadHandler.text;
                    // 显式相应数据
                    Debug.Log(jsonString);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }

        // 序列化数据
        APIResponseData jsonObject = JsonConvert.DeserializeObject<APIResponseData>(jsonString);

        return jsonObject;
    }
}