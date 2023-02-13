using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdExample : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;

    void Awake()
    {
        // 获取当前平台的 Ad Unit ID（广告单元 ID）：
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
    }

    // 将内容加载到广告单元中：
    public void LoadAd()
    {
        // 重要！仅在初始化之后再加载内容（在此示例中，初始化在另一个脚本中处理）。
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // 展示广告单元中加载的内容：
    public void ShowAd()
    {
        // 请注意，如果未事先加载广告内容，此方法将失败
        Debug.Log("Showing Ad: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
    }

    // 实现 Load Listener 和 Show Listener 接口方法： 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        //（可选）如果广告单元成功加载内容，执行代码。
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
        //（可选）如果广告单元加载失败，执行代码（例如再次尝试）。
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        //（可选）如果广告单元展示失败，执行代码（例如加载另一个广告）。
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) { }
}
