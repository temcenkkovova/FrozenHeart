
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
  public List<InventoryItem> inventoryItems = new List<InventoryItem>();
  public bool HasKey()
  {
    bool key = false;
    if (inventoryItems == null) return false;
    foreach (var item in inventoryItems)
    {
      Debug.Log(item.nameItem);
      key = item.nameItem == "Key";
    }

    Debug.Log(key);
    return key;
  }


  public void AddKey()
  {
    InventoryItem item = new InventoryItem("Key");
    inventoryItems.Add(item);
    Debug.Log(inventoryItems[0].nameItem);
  }

  public void RemoveKey()
  {
    inventoryItems.RemoveRange(0, 1);
  }
}