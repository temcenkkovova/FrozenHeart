using UnityEngine;

public class FloorCollision : MonoBehaviour
{
  public FloorController floorController;

  private bool isEntered = false;

  public Transform teleportPointPosition;

  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      if (isEntered) return;
      PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
      playerMovement.SetMovementBlocked(true);
      floorController.ChangeFloor(gameObject.name);
      playerMovement.Teleport(teleportPointPosition.position);
      isEntered = true;
      playerMovement.SetMovementBlocked(false);
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