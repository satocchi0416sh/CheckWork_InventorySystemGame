using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    private bool _isInventoryOpen;
    
    void Start()
    {
        inventoryPanel.SetActive(false);
        _isInventoryOpen = false;
    }
    
    void Update()
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
}
