using System;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
  public LayerMask layers;

  public IInteractable CurrentInteractable { get; private set; }
  public event Action<IInteractable> OnInteracted;
  public event Action OnLeaveInteracted;
  void OnTriggerEnter(Collider other)
  {
    Debug.Log(other.name);
    bool isInteractable = (layers.value & (1 << other.gameObject.layer)) != 0;
    if (isInteractable)
    {

      IInteractable interactable = other.GetComponent<IInteractable>();
      interactable.OnDestroyObject += HandleDestroyObject;
      if (interactable == CurrentInteractable) return;
      if (interactable == null) return;
      CurrentInteractable = interactable;
      OnInteracted?.Invoke(interactable);

    }
  }

  void OnTriggerExit(Collider other)
  {

    bool isInteractable = (layers.value & (1 << other.gameObject.layer)) != 0;
    if (isInteractable)
    {
      IInteractable interactable = other.GetComponent<IInteractable>();
      interactable.OnDestroyObject -= HandleDestroyObject;
      if (interactable == CurrentInteractable)
        CurrentInteractable = null;
      OnLeaveInteracted?.Invoke();
    }


  }
  public void HandleDestroyObject()
  {
    CurrentInteractable = null;
  }


}