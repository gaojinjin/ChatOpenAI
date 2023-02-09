using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;
using System.Linq;
using Cysharp.Threading.Tasks;


public class SendChatGPT : MonoBehaviour
{
    /// <summary>
    /// APIエンドポイント
    /// </summary>
    const string API_END_POINT = "https://api.openai.com/v1/completions";
    /// <summary>
    /// API KEY
    /// </summary>
    const string API_KEY = "USER_API_KEY";
    /// <summary>
    /// 入力欄
    /// </summary>
    [SerializeField]
    private InputField Input;
    [SerializeField]
    private Text Output;

    [SerializeField]
    private Button ExecButton;
    [SerializeField]
    private Button QuitButton;

    private void Start()
    {
        // API実行ボタン
        ExecButton.onClick.AddListener(async () =>
        {
            //入力取得
            string prompt = Input.text;
            if (!string.IsNullOrEmpty(prompt))
            {
                //レスポンス取得
                var response = await GetAPIResponse(prompt);
                //レスポンスからテキスト取得
                string outputText = response.Choices.FirstOrDefault().Text;
                Output.text = outputText.TrimStart('\n');
                Debug.Log(outputText);
            }

        });
        // 終了ボタン
        QuitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    /// <summary>
    /// APIからレスポンス取得
    /// </summary>
    /// <param name="prompt"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async UniTask<APIResponseData> GetAPIResponse(string prompt)
    {
        APIRequestData requestData = new()
        {
            Prompt = prompt,
            MaxTokens = 300 //レスポンスのテキストが途切れる場合、こちらを変更する
        };

        string requestJson = JsonConvert.SerializeObject(requestData, Formatting.Indented);
        Debug.Log(requestJson);

        // POSTするデータ
        byte[] data = System.Text.Encoding.UTF8.GetBytes(requestJson);


        string jsonString = null;
        // POSTリクエストを送信
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
                    Debug.Log("リクエスト中");
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("リクエスト成功");
                    jsonString = request.downloadHandler.text;
                    // レスポンスデータを表示
                    Debug.Log(jsonString);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }

        // デシリアライズ
        APIResponseData jsonObject = JsonConvert.DeserializeObject<APIResponseData>(jsonString);

        return jsonObject;
    }
}