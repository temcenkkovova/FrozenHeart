using UnityEngine;

public class DoorComponent : MonoBehaviour, IInteractable
{
  public Transform doorPivot;
  public bool IsOpen { get; private set; } = false;

  public void Interact()
  {
    OpenDoor();
  }

  private void OpenDoor()
  {
    if (IsOpen)
    {
      doorPivot.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
      IsOpen = false;
    }
    else
    {
      doorPivot.transform.localRotation = Quaternion.Euler(0f, -90f, 90f);
      IsOpen = true;
    }

  }
}