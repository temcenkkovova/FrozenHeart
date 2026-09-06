
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
  public List<InventoryItem> inventoryItems = new List<InventoryItem>();
  public event Action<int> OnInventoryChanged;
  private int inventoryCount = 0;
  public bool HasKey()
  {
    bool key = false;
    if (inventoryItems == null) return false;
    foreach (var item in inventoryItems)
    {

      key = item.nameItem == "Key";
    }

    Debug.Log(key);
    return key;
  }


  public void AddKey()
  {
    InventoryItem item = new InventoryItem("Key");
    inventoryItems.Add(item);
    inventoryCount++;
    OnInventoryChanged(inventoryCount);

  }

  public void RemoveKey()
  {
    inventoryItems.RemoveRange(0, 1);
    inventoryCount--;
    OnInventoryChanged(inventoryCount);
  }
}