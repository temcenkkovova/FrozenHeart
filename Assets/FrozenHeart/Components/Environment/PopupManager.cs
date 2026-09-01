
using System.Collections;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
  public Popup worldPopup;

  public InteractionDetector interactionDetector;
  private Vector3 worldOffset = new(0f, 0.5f, 0f);
  private Camera mainCamera;
  public PlayerInputController playerInputController;

  private bool isActive;



  void Start()
  {
    mainCamera = Camera.main;
    interactionDetector.OnInteracted += ShowPopup;
    playerInputController.OnInteractPressed += HidePopup;
    interactionDetector.OnLeaveInteracted += HidePopup;
  }

  public void ShowPopup(IInteractable iteractable)
  {
    if (isActive) return;
    worldPopup.gameObject.transform.position = mainCamera.WorldToScreenPoint(iteractable.IteractableTransform.position + worldOffset);
    worldPopup.gameObject.SetActive(true);
    isActive = true;
    worldPopup.Init(iteractable.InteractableText);

  }

  public void HidePopup()
  {

    worldPopup.gameObject.SetActive(false);
    isActive = false;
  }
  void OnDisable()
  {
    interactionDetector.OnInteracted -= ShowPopup;
    playerInputController.OnInteractPressed -= HidePopup;
    interactionDetector.OnLeaveInteracted -= HidePopup;
  }


}