using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
  public LayerMask layers;

  public IInteractable CurrentInteractable { get; private set; }
  void OnTriggerEnter(Collider other)
  {
    Debug.Log("q");
    bool isInteractable = (layers.value & (1 << other.gameObject.layer)) != 0;
    if (isInteractable)
    {
      Debug.Log("t");
      IInteractable interactable = other.GetComponent<IInteractable>();
      if (interactable == null) return;
      CurrentInteractable = interactable;
      Debug.Log("Here");
    }
  }

  void OnTriggerExit(Collider other)
  {

    bool isInteractable = (layers.value & (1 << other.gameObject.layer)) != 0;
    if (isInteractable)
    {
      IInteractable interactable = other.GetComponent<IInteractable>();
      if (interactable == CurrentInteractable)
        CurrentInteractable = null;
    }
  }


}