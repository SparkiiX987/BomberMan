using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Item> itemsList = new List<Item>();
    public List<GameObject> itemsSlots = new List<GameObject>();
    public GameObject itemPrefab;
    public Item emptyItem;
    public GridLayoutGroup gridLayoutGroup;
    private Slot slot;

    private void Awake()
    {
        InitializeInventory();
        slot = GetComponent<Slot>();
    }

    public void InitializeInventory()
    {
        foreach (Item item in itemsList)
        {
            GameObject newItemSlot = Instantiate(itemPrefab, gridLayoutGroup.transform); 
            itemsSlots.Add(newItemSlot); 
            slot = newItemSlot.GetComponent<Slot>();
            slot.UpdateItem(item); 
        }
    }

    public void AddItemByID(Item item)
    {
        for (int i = 0; i < itemsList.Count; i++)
        {
            if (itemsList[i] == emptyItem)
            {
                itemsList[i] = item; 
                slot = itemsSlots[i].GetComponent<Slot>();
                slot.UpdateItem(item); 
                return;
            }
        }
    }

    public void RemoveItemByID(Item item)
    {
        int index = itemsList.IndexOf(item);
        itemsList.RemoveAt(index);
        itemsList.Add(emptyItem); 

        foreach (GameObject itemPrefab in itemsSlots)
        {
            itemPrefab.GetComponent<Slot>().UpdateItem(itemsList[itemsSlots.IndexOf(itemPrefab)]);
        }
    }
}