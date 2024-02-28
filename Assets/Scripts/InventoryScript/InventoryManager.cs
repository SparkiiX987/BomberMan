using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public List<ItemSO> inventoryList = new List<ItemSO>();
    public ItemSO emptyItem;
    [field: SerializeField] public int inventorySize { get; private set; } = 6;

    public void Awake()
    {
        InitializeInventory();
    }

    public void InitializeInventory() 
    {
        while (inventoryList.Count < inventorySize)
        {
            inventoryList.Add(emptyItem);
        }
    }

    public void AddItemByID(ItemSO item)
    {

    }

    public void RemoveItemByID(ItemSO item)
    {
        for (int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i] == item)
            {
                inventoryList.RemoveAt(item.id);
                inventoryList.Add(emptyItem);
                break;
            }
        }
    }
}