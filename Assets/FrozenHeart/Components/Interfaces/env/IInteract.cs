using System;
using UnityEngine;

public interface IInteractable
{
  string InteractableText { get; set; }
  Transform IteractableTransform { get; set; }
  public event Action OnDestroyObject;


  void Interact()
  {

  }
}