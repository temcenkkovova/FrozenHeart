using UnityEngine;

public class ExitHouse : MonoBehaviour
{

  public QuestManager questManager;
  public FreezeController freezeController;
  public EnterHouse enterHouse;
  private bool isExited = false;
  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      if (isExited) return;
      isExited = true;
      if (questManager.currentQuestCount >= 8)
      {
        questManager.HandleQuestItemInteract(gameObject.tag);

      }
      else
      {
        Debug.Log("You are  leaving too earlier");
      }
      enterHouse.ChangeStatus(false);
      freezeController.ChangeAlphaValue(0f);
    }
  }
  public void ChangeExitStatus(bool newStatus)
  {
    isExited = newStatus;
  }
}