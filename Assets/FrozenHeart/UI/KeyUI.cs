using TMPro;
using UnityEngine;

public class KeyUI : MonoBehaviour
{
  public TMP_Text textField;

  public PlayerInventory playerInventory;

  void Start()
  {
    playerInventory.OnInventoryChanged += ChangeKeyValue;
  }

  public void ChangeKeyValue(int value)
  {
    textField.text = value.ToString();
  }

  void OnDisable()
  {
    playerInventory.OnInventoryChanged -= ChangeKeyValue;
  }
}