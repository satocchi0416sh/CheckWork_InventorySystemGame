using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void OnUseItemButtonClicked()
    {
        Debug.Log(gameObject.name + "を使いました！");
        
        // インデックスを取得
        int childIndex = transform.GetSiblingIndex();
        InventoryManager.Instance.RemoveItem(childIndex);
        
        Destroy(gameObject);
    }
}
