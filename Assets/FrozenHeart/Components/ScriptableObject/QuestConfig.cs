using UnityEngine;

[CreateAssetMenu(menuName = "Quest")]
public class QuestConfig : ScriptableObject
{
  public string title;
  public string requiredItem;
  public int requiredAmount;
}