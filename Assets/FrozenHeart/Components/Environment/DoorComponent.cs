using System;
using UnityEngine;

public class DoorComponent : MonoBehaviour, IInteractable
{
  public Transform doorPivot;
  public bool IsOpen { get; private set; } = false;
  public string InteractableText { get; set; } = "Open";
  public Transform IteractableTransform { get; set; }
  public event Action OnDestroyObject;
  [SerializeField] private bool IsLocked = false;
  public PlayerInventory playerInventory;

  void Awake()
  {
    IteractableTransform = transform;
  }
  void Start()
  {

  }

  public void UnlockedDoor()
  {
    IsLocked = false;
  }
  void Update()
  {
    if (IsLocked)
    {
      InteractableText = "Open with key";
    }
    if (IsOpen)
    {
      InteractableText = "Close";
    }

  }
  public void Interact()
  {
    if (IsLocked)
    {
      if (playerInventory.HasKey())
      {
        UnlockedDoor();
      }
      else
      {
        Debug.Log("You don`t have a key");
      }
    }

    if (!IsLocked)
    {
      OpenDoor();
    }
  }

  private void OpenDoor()
  {
    if (IsLocked)
    {
      Debug.Log("You have to find a key");
    }
    else
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
}