using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject healthPotionPrefab;
    [SerializeField] private GameObject manaPotionPrefab;
    private bool _isInventoryOpen;
    private List<string> _items = new List<string>();
    
    // --------------------------
    // これはシングルトンパターンといって、一つのインスタンスしか生成されないようにするためのもの！
    // これによって、どこからでもこのクラスのインスタンスにアクセスできるようになる！
    public static InventoryManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // --------------------------
    
    private void Start()
    {
        inventoryPanel.SetActive(false);
        _isInventoryOpen = false;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }
    }
    
    private void ToggleInventory()
    {
        if (_isInventoryOpen)
        {
            inventoryPanel.SetActive(false);
            _isInventoryOpen = false;
        }
        else
        {
            inventoryPanel.SetActive(true);
            _isInventoryOpen = true;
        }
    }
    
    public void AddItem(string item)
    {
        _items.Add(item);
        switch (item)
        {
            case "HealthPotion":
                Instantiate(healthPotionPrefab, inventoryPanel.transform);
                break;
            case "ManaPotion":
                Instantiate(manaPotionPrefab, inventoryPanel.transform);
                break;
        }
    }
    
    public void RemoveItem(int index)
    {
        // 同名のアイテムは他にもあるので、正しいアイテムが削除されるようにするために、
        // 名前ではなく、インデックスを使って削除する！
        // インデックスはItemスクリプトのOnUseItemButtonClickedメソッドで取得している！
        _items.RemoveAt(index);
    }
}
