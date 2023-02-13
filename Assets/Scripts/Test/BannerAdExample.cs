using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class BannerAdExample : MonoBehaviour
{
    // 在本示例中，这些按钮用于功能测试：
    [SerializeField] Button _loadBannerButton;
    [SerializeField] Button _showBannerButton;
    [SerializeField] Button _hideBannerButton;

    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

    [SerializeField] string _androidAdUnitId = "Banner_Android";
    [SerializeField] string _iOSAdUnitId = "Banner_iOS";
    string _adUnitId = null; // 对于不受支持的平台，此值将保持为 null。

    void Start()
    {
        // 获取当前平台的 Ad Unit ID（广告单元 ID）：
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        // 在准备好展示广告之前禁用该按钮：
        _showBannerButton.interactable = false;
        _hideBannerButton.interactable = false;

        // 设置横幅广告位置：
        Advertisement.Banner.SetPosition(_bannerPosition);

        // 配置 Load Banner（加载横幅广告）按钮在单击该按钮时调用 LoadBanner() 方法：
        _loadBannerButton.onClick.AddListener(LoadBanner);
        _loadBannerButton.interactable = true;
    }

    // 实现一个在单击 Load Banner（加载横幅广告）按钮时调用的方法：
    public void LoadBanner()
    {
        // 设置选项以将加载事件告知 SDK：
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        // 向广告单元加载横幅广告内容：
        Advertisement.Banner.Load(_adUnitId, options);
    }

    // 实现在 loadCallback 事件触发时执行的代码：
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");

        // 配置 Show Banner（展示横幅广告）按钮在单击该按钮时调用 ShowBannerAd() 方法：
        _showBannerButton.onClick.AddListener(ShowBannerAd);
        // 配置 Hide Banner（隐藏横幅广告）按钮在单击该按钮时调用 HideBannerAd() 方法：
        _hideBannerButton.onClick.AddListener(HideBannerAd);

        // 启用这两个按钮：
        _showBannerButton.interactable = true;
        _hideBannerButton.interactable = true;
    }

    // 实现在 load errorCallback 事件触发时执行的代码：
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
        //（可选）执行其他代码，例如尝试加载另一个广告。
    }

    // 实现一个在单击 Show Banner（展示横幅广告）按钮时调用的方法：
    void ShowBannerAd()
    {
        // 设置选项以将显示事件告知 SDK：
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        // 展示加载的横幅广告单元：
        Advertisement.Banner.Show(_adUnitId, options);
    }

    // 实现一个在单击 Hide Banner（隐藏横幅广告）按钮时调用的方法：
    void HideBannerAd()
    {
        // 隐藏横幅广告：
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }

    void OnDestroy()
    {
        // 清理监听器：
        _loadBannerButton.onClick.RemoveAllListeners();
        _showBannerButton.onClick.RemoveAllListeners();
        _hideBannerButton.onClick.RemoveAllListeners();
    }
}