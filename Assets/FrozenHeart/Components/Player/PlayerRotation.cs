using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
  public float rotateSpeed = 5f;

  private PlayerInputController playerInputController;
  void Awake()
  {
    playerInputController = GetComponent<PlayerInputController>();
  }

  void Update()
  {
    RotateByMouse(playerInputController.MousePosition);
  }
  public void RotateByMouse(Vector2 input)
  {
    Vector3 mouseDir = new Vector3();
    Ray ray = Camera.main.ScreenPointToRay(input);
    Plane groundPlane = new Plane(Vector3.up, Vector3.zero);


    if (groundPlane.Raycast(ray, out float distance))
    {
      Vector3 mouseWorldPos = ray.GetPoint(distance);
      mouseDir = mouseWorldPos - transform.position;
    }

    mouseDir.y = 0f;

    if (mouseDir.sqrMagnitude < 0.01) return;

    mouseDir.Normalize();

    Quaternion targetRotation = Quaternion.LookRotation(mouseDir);
    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
  }
}