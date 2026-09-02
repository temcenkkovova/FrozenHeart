using System;

public class Quest
{
  public string titleQuest;
  public string requiredItemName;
  public int requiredAmount;
  public int currentAmount;
  public event Action<int> OnCurrentAmountChanged;
  public event Action<QuestConfig> OnCompleted;
  private QuestConfig questConfig;


  public Quest(QuestConfig questConfig)
  {
    this.questConfig = questConfig;
    titleQuest = questConfig.title;
    requiredAmount = questConfig.requiredAmount;
    requiredItemName = questConfig.requiredItem;
    currentAmount = 0;
  }


  public void ChangeQuestProgress()
  {
    requiredAmount++;
    OnCurrentAmountChanged.Invoke(requiredAmount);

    if (currentAmount >= requiredAmount)
    {
      OnCompleted?.Invoke(questConfig);
    }
  }

}