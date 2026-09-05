using UnityEngine;

public class EnterHouse : MonoBehaviour
{

  public QuestManager questManager;

  public FreezeController freezeController;
  public ExitHouse exitHouse;
  private bool isEntered = false;
  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      if (isEntered) return;
      isEntered = true;
      freezeController.ChangeAlphaValue(0.3f);
      questManager.HandleQuestItemInteract(gameObject.tag);
      exitHouse.ChangeExitStatus(false);
      // Destroy(gameObject, 1f);
    }
  }

  public void ChangeStatus(bool newStatus)
  {
    isEntered = newStatus;
  }
}