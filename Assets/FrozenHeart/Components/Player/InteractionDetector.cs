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

    bool isInteractable = (layers.value & (1 << other.gameObject.layer)) != 0;
    if (isInteractable)
    {

      IInteractable interactable = other.GetComponent<IInteractable>();

      if (interactable == CurrentInteractable || interactable == null) return;
      ClearCurrent();
      CurrentInteractable = interactable;
      CurrentInteractable.OnDestroyObject += HandleDestroyObject;
      OnInteracted?.Invoke(CurrentInteractable);

    }
  }

  void OnTriggerExit(Collider other)
  {

    IInteractable interactable = other.GetComponent<IInteractable>();
    if (interactable == null || interactable != CurrentInteractable)
      return;
    ClearCurrent();


  }
  private void ClearCurrent()
  {
    if (CurrentInteractable == null)
      return;

    CurrentInteractable.OnDestroyObject -= HandleDestroyObject;
    CurrentInteractable = null;
    OnLeaveInteracted?.Invoke();
  }
  public void HandleDestroyObject()
  {
    CurrentInteractable = null;
  }


}