using UnityEngine;

public class HideQuest : MonoBehaviour
{
  public GameObject questObject;
  public QuestManager questManager;


  void Start()
  {
    if (questManager == null) return;
    questManager.OnShowHiddenQuest += ShowQuestObjects;
    questObject.SetActive(false);
  }


  public void ShowQuestObjects()
  {
    questObject.SetActive(true);
  }

  void OnDisable()
  {
    if (questManager == null) return;
    questManager.OnShowHiddenQuest -= ShowQuestObjects;
  }
}