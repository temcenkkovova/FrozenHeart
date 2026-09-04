using System.Collections.Generic;
using UnityEngine;

public class CameraWallHider : MonoBehaviour
{
  [SerializeField] private Transform target;
  [SerializeField] private LayerMask wallMask;
  [SerializeField, Min(0.01f)] private float radius = 0.2f;

  private HashSet<CameraObstacle> hidden = new();
  private HashSet<CameraObstacle> detected = new();

  private void LateUpdate()
  {
    if (target == null)
    {
      RestoreAll();
      return;
    }

    detected.Clear();

    Vector3 direction = target.position - transform.position;
    float distance = direction.magnitude;

    if (distance > 0.001f)
    {
      RaycastHit[] hits = Physics.SphereCastAll(
          transform.position,
          radius,
          direction / distance,
          distance,
          wallMask,
          QueryTriggerInteraction.Ignore
      );

      foreach (RaycastHit hit in hits)
      {
        CameraObstacle obstacle =
            hit.collider.GetComponentInParent<CameraObstacle>();

        if (obstacle != null && obstacle.isActiveAndEnabled)
          detected.Add(obstacle);
      }
    }

    // Возвращаем стены, которые больше не мешают.
    foreach (CameraObstacle obstacle in hidden)
    {
      if (obstacle != null && !detected.Contains(obstacle))
        obstacle.Restore();
    }

    // Скрываем стены между камерой и героем.
    foreach (CameraObstacle obstacle in detected)
      obstacle.Hide();

    // Переиспользуем наборы на следующем кадре.
    (hidden, detected) = (detected, hidden);
  }

  private void RestoreAll()
  {
    foreach (CameraObstacle obstacle in hidden)
    {
      if (obstacle != null)
        obstacle.Restore();
    }

    hidden.Clear();
    detected.Clear();
  }

  private void OnDisable()
  {
    RestoreAll();
  }
}