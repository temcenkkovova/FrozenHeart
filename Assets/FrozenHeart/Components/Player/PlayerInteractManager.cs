using UnityEngine;

public class PlayerInteractManager : MonoBehaviour
{
  private PlayerInputController playerInputController;
  private InteractionDetector interactionDetector;

  private PlayerInventory playerInventory;


  void Awake()
  {
    playerInputController = GetComponent<PlayerInputController>();
    interactionDetector = GetComponent<InteractionDetector>();
    playerInventory = GetComponent<PlayerInventory>();

  }


  void Start()
  {
    playerInputController.OnInteractPressed += HandleInteract;
  }
  private void HandleInteract()
  {
    if (interactionDetector.CurrentInteractable != null)
      interactionDetector.CurrentInteractable.Interact();


  }

  void OnDisable()
  {
    playerInputController.OnInteractPressed -= HandleInteract;
  }
}