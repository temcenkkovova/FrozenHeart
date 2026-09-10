using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnterHouseEvent : MonoBehaviour, IInteractable
{
  public FloorController floorController;
  public AudioClip enterHouseSound;
  public CanvasGroup blackScreenCanvas;

  public Transform playerEnterPos;
  public PlayerBootstrap playerBootstrap;
  public string InteractableText { get; set; } = "Open";
  public Transform IteractableTransform { get; set; }

  public event Action OnDestroyObject;

  public float fadeDuration = 2f;
  private bool IsEntered = false;

  private Tween tween;

  void Awake()
  {
    blackScreenCanvas.alpha = 0f;
    IteractableTransform = transform;
  }


  public void Interact()
  {
    if (IsEntered) return;
    IsEntered = true;
    StartCoroutine(ShowHouse());

  }

  public Tween FadeToBlack()
  {
    tween?.Kill();

    blackScreenCanvas.blocksRaycasts = true;

    tween = blackScreenCanvas.DOFade(1f, fadeDuration).SetEase(Ease.InOutQuad).SetUpdate(true);
    return tween;
  }

  public Tween FadeFromBlack()
  {
    tween?.Kill();

    blackScreenCanvas.blocksRaycasts = true;
    blackScreenCanvas.alpha = 1f;

    tween = blackScreenCanvas.DOFade(0f, fadeDuration).SetEase(Ease.InOutQuad).SetUpdate(true).OnComplete(() => blackScreenCanvas.blocksRaycasts = false);
    return tween;
  }



  private IEnumerator ShowHouse()
  {

    floorController.gameObject.SetActive(true);

    PlayerMovement playerMovement = playerBootstrap.GetComponent<PlayerMovement>();

    playerMovement.SetMovementBlocked(true);
    yield return FadeToBlack().WaitForCompletion();
    floorController.gameObject.SetActive(true);
    yield return null;

    playerMovement.Teleport(playerEnterPos.position);
    OnDestroyObject?.Invoke();
    yield return new WaitForFixedUpdate();

    yield return FadeFromBlack().WaitForCompletion();

    playerMovement.SetMovementBlocked(false);

  }
  private void OnDestroy()
  {
    tween?.Kill();
  }
}