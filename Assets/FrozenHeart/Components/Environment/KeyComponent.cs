using System;
using UnityEngine;

public class KeyComponent : MonoBehaviour, IInteractable
{

  public string InteractableText { get; set; } = "Take";
  public Transform IteractableTransform { get; set; }
  public event Action OnDestroyObject;
  public PlayerInventory playerInventory;

  public void Interact()
  {
    playerInventory.AddKey();
  }
}