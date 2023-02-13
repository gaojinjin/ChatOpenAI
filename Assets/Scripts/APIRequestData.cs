using Newtonsoft.Json;

/// <summary>
/// APIリクエスト
/// 
/// https://beta.openai.com/docs/api-reference/authentication
/// </summary>

[JsonObject]
public class APIRequestData
{
    [JsonProperty("model")]
    public string Model { get; set; } = "text-davinci-003";
    [JsonProperty("prompt")]
    public string Prompt { get; set; } = "";
    [JsonProperty("temperature")]
    public int Temperature { get; set; } = 0;
    [JsonProperty("max_tokens")]
    public int MaxTokens { get; set; } = 100;
}

/// <summary>
/// APIレスポンス
/// 
/// https://beta.openai.com/docs/api-reference/authentication
/// </summary>
[JsonObject]
public class APIResponseData
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("object")]
    public string Object { get; set; }
    [JsonProperty("model")]
    public string Model { get; set; }
    [JsonProperty("created")]
    public int Created { get; set; }
    [JsonProperty("choices")]
    public ChoiceData[] Choices { get; set; }
    [JsonProperty("usage")]
    public UsageData Usage { get; set; }
}

[JsonObject]
public class UsageData
{
    [JsonProperty("prompt_tokens")]
    public int PromptTokens { get; set; }
    [JsonProperty("completion_tokens")]
    public int CompletionTokens { get; set; }
    [JsonProperty("total_tokens")]
    public int TotalTokens { get; set; }
}

[JsonObject]
public class ChoiceData
{
    [JsonProperty("text")]
    public string Text { get; set; }
    [JsonProperty("index")]
    public int Index { get; set; }
    [JsonProperty("logprobs")]
    public string Logprobs { get; set; }
    [JsonProperty("finish_reason")]
    public string FinishReason { get; set; }
}