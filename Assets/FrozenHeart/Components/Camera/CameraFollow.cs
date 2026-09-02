using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform targetTr;
  public float smoothTime = 0.5f;
  public Vector3 offset;

  private Vector3 velocity;

  void Start()
  {
    if (targetTr != null)
      offset = transform.position - targetTr.position;
  }

  private void LateUpdate()
  {
    if (targetTr == null) return;

    Vector3 targetPosition = targetTr.position + offset;


    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);





  }

}