using UnityEngine;

public class ExitHouse : MonoBehaviour
{

  public QuestManager questManager;
  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      if (questManager.currentQuestCount >= 8)
      {
        questManager.HandleQuestItemInteract(gameObject.tag);
        Destroy(gameObject, 1f);
      }
      else
      {
        Debug.Log("You are  leaving too earlier");
      }

    }
  }
}