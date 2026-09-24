using UnityEngine;

public class Bonfire : MonoBehaviour
{
  public GameObject bonfire;
  public GameObject blazingBonfire;
  public QuestManager questManager;


  public void Start()
  {
    blazingBonfire.SetActive(false);

    if (questManager == null) return;
    questManager.OnShowHiddenQuest += ShowBlazingBonfire;
  }

  public void ShowBlazingBonfire()
  {
    //bonfire.SetActive(false);
    blazingBonfire.SetActive(true);
  }

  void OnDisable()
  {
    if (questManager == null) return;
    questManager.OnShowHiddenQuest -= ShowBlazingBonfire;
  }
}