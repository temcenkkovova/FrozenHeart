
using TMPro;
using UnityEngine;
public class Popup : MonoBehaviour
{
  public TMP_Text textField;

  public void Init(string text)
  {
    textField.text = text;
  }
}