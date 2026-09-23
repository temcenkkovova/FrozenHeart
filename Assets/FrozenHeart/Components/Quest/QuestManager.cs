using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

  public event Action<Quest> OnQuestChanged;

  public List<QuestConfig> questConfig;

  public event Action OnShowHiddenQuest;

  private Quest activeQuest;
  public int currentQuestCount { get; private set; } = 0;

  void Start()
  {
    SetQuest();
  }

  public void SetQuest()
  {
    if (currentQuestCount >= questConfig.Count) return;

    activeQuest = new Quest(questConfig[currentQuestCount]);
    activeQuest.OnCompleted += HandleCompleteActiveQuest;
    if (questConfig[currentQuestCount].id == 2)
    {
      OnShowHiddenQuest?.Invoke();
    }


    OnQuestChanged?.Invoke(activeQuest);


  }
  public void HandleCompleteActiveQuest(QuestConfig questConfig)
  {
    activeQuest.OnCompleted -= HandleCompleteActiveQuest;
    currentQuestCount++;
    SetQuest();
  }
  public void HandleQuestItemInteract(string name)
  {

    activeQuest.ChangeQuestProgress(name);
  }
}