using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void OnUseItemButtonClicked(string item)
    {
        switch (item)
        {
            case "HealthPotion":
                Debug.Log("HP回復！");
                break;
            case "ManaPotion":
                Debug.Log("MP回復！");
                break;
        }
        
        // インデックスを取得
        int childIndex = transform.GetSiblingIndex();
        InventoryManager.Instance.RemoveItem(childIndex);
        
        // ボタン自体を削除
        Destroy(gameObject);
    }
}
