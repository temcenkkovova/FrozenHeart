using UnityEngine;

public interface IInteractable
{
  string InteractableText { get; set; }
  Transform IteractableTransform { get; set; }

  void Interact()
  {

  }
}