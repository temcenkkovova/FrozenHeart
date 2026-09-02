using TMPro;
using UnityEngine;

public class QuestManagerUI : MonoBehaviour
{
  public GameObject questPanel;

  public TMP_Text titleField;
  public TMP_Text requiredField;
  public TMP_Text requiredAmountField;
  public TMP_Text currentAmountField;

  public QuestManager questManager;

  private Quest quest;

  void Start()
  {
    questManager.OnQuestChanged += ShowQuest;
  }

  public void ShowQuest(Quest quest)
  {
    if (this.quest != null)
      this.quest.OnCurrentAmountChanged -= ShowNewAmount;
    questPanel.SetActive(true);
    this.quest = quest;
    titleField.text = quest.titleQuest;
    //requiredField.text = quest.requiredItemName;
    currentAmountField.text = quest.currentAmount.ToString();
    requiredAmountField.text = quest.requiredAmount.ToString();

    quest.OnCurrentAmountChanged += ShowNewAmount;
  }


  public void HideQuestPanel()
  {
    questPanel.SetActive(false);
  }
  public void ShowNewAmount(int amount)
  {
    currentAmountField.text = amount.ToString();
  }
  void OnDisable()
  {
    questManager.OnQuestChanged -= ShowQuest;
    quest.OnCurrentAmountChanged -= ShowNewAmount;
  }
}