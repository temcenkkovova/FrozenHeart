using System;
using System.Collections;
using UnityEngine;

public class QuestItem : MonoBehaviour, IInteractable
{
  public string InteractableText { get; set; } = "Take";
  public Transform IteractableTransform { get; set; }
  public QuestManager questManager;
  public event Action OnDestroyObject;

  void Awake()
  {
    IteractableTransform = transform;
  }

  public void Interact()
  {
    if (!questManager.CheckCurrentQuest(gameObject.tag)) return;
    questManager.HandleQuestItemInteract(gameObject.tag);
    StartCoroutine(destroyCoroutine());
  }

  IEnumerator destroyCoroutine()
  {
    yield return new WaitForSeconds(0.2f);
    OnDestroyObject.Invoke();
    Destroy(gameObject);
  }


}