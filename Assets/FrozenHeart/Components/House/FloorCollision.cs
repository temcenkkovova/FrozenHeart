using UnityEngine;

public class FloorCollision : MonoBehaviour
{
  public FloorController floorController;
  private bool isEntered = false;

  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      if (isEntered) return;
      floorController.ChangeFloor(gameObject.name);
      isEntered = true;
    }
  }
  void OnTriggerExit(Collider other)
  {
    if (other.tag == "Player")
    {

      isEntered = false;
    }
  }
}