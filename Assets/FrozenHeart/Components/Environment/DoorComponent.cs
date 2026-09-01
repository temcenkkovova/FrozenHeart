using UnityEngine;

public class DoorComponent : MonoBehaviour, IInteractable
{
  public Transform doorPivot;
  public bool IsOpen { get; private set; } = false;
  public string InteractableText { get; set; } = "Open";
  public Transform IteractableTransform { get; set; }

  void Awake()
  {
    IteractableTransform = transform;
  }
  void Start()
  {

  }
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
      InteractableText = "Open";
    }
    else
    {
      doorPivot.transform.localRotation = Quaternion.Euler(0f, -90f, 90f);
      IsOpen = true;
      InteractableText = "Close";
    }

  }
}