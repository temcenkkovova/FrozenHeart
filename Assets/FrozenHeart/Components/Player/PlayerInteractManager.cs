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
    // playerInputController.OnInteractPressed += HandleInteract;
  }
  private void HandleInteract()
  {
    Debug.Log("tt");
    if (interactionDetector.CurrentInteractable != null)
    {
      Debug.Log("hjere");
      interactionDetector.CurrentInteractable.Interact();
    }
  }

  void OnEnable()
  {
    playerInputController.OnInteractPressed += HandleInteract;
  }
  void OnDisable()
  {
    playerInputController.OnInteractPressed -= HandleInteract;
  }
}