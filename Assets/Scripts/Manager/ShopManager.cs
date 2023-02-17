using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Transform itemPar;
    public ShopItem item;
    private void OnEnable()
    {
        
        foreach (Transform item in itemPar)
        {
            Destroy(item.gameObject);    

        }
        //显式的更新物品信息
        for (int i = 0; i < GameManager.Instance.data.shop.shop.Length; i++)
        {
            ShopItem itemGo = Instantiate(item, itemPar);
            itemGo.Init(GameManager.Instance.data.shop.shop[i]);
        }
    }


}
