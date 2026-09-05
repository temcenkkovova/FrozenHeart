using UnityEngine;

public class EnterHouse : MonoBehaviour
{

  public QuestManager questManager;

  public FreezeController freezeController;
  public ExitHouse exitHouse;
  public ColdManager coldManager;
  private bool isEntered = false;
  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      if (isEntered) return;
      isEntered = true;
      coldManager.SetInsideHouse(true);
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