using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public Button buyBut;
    public Image icoImg;
    public TextMeshProUGUI nameText, descriptionText;

    public void  Init(Shop shop) {
        nameText.text = shop.name;
        descriptionText.text = shop.description;
        icoImg.sprite = Resources.Load<Sprite>(shop.icoName);
        buyBut.onClick.AddListener(()=> {
           /* if (GameManager.Instance.data.user.coin >= shop.expend)
            {
                GameManager.Instance.data.user.coin -= shop.expend;
            }
            else
            {
                Debug.Log("猕猴桃币不足");
            }*/
            //观看广告 观看广告成功后增加猕币

        });
    }
    
}
