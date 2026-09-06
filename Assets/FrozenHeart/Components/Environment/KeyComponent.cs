using System;
using System.Collections;
using UnityEngine;

public class KeyComponent : MonoBehaviour, IInteractable
{

  public string InteractableText { get; set; } = "Take";
  public Transform IteractableTransform { get; set; }
  public event Action OnDestroyObject;
  public PlayerInventory playerInventory;
  void Awake()
  {
    IteractableTransform = transform;
  }
  public void Interact()
  {

    playerInventory.AddKey();

    StartCoroutine(destroyCoroutine());
  }

  IEnumerator destroyCoroutine()
  {
    yield return new WaitForSeconds(0.2f);
    OnDestroyObject.Invoke();
    Destroy(gameObject);
  }
}