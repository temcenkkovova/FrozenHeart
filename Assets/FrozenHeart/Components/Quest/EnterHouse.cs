using UnityEngine;

public class EnterHouse : MonoBehaviour
{

  public QuestManager questManager;
  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      questManager.HandleQuestItemInteract(gameObject.tag);
      Destroy(gameObject, 1f);
    }
  }
}