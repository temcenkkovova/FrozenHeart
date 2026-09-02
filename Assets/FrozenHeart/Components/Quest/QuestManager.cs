using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

  public event Action<Quest> OnQuestChanged;

  public List<QuestConfig> questConfig;

  private Quest activeQuest;
  private int currentQuestCount = 0;

  void Start()
  {
    SetQuest();
  }

  public void SetQuest()
  {

    activeQuest = new Quest(questConfig[currentQuestCount]);
    OnQuestChanged?.Invoke(activeQuest);
  }
}