using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private float speed;
  private PlayerInputController playerInput;
  private Rigidbody rb;



  public bool MovementBlocked { get; private set; }
  void Awake()
  {
    playerInput = GetComponent<PlayerInputController>();
    rb = GetComponent<Rigidbody>();

  }


  void FixedUpdate()
  {
    Vector3 currentVelocity = rb.linearVelocity;
    Vector3 horizontalVelocity = Vector3.zero;
    if (playerInput.isMoving && !MovementBlocked)
    {
      horizontalVelocity = transform.forward * speed;
    }

    rb.linearVelocity = new Vector3(horizontalVelocity.x, currentVelocity.y, horizontalVelocity.z);

  }

  public void SetMovementBlocked(bool blocked)
  {
    MovementBlocked = blocked;


    if (blocked)
    {

      Vector3 velocity = rb.linearVelocity;
      rb.linearVelocity = new Vector3(0f, velocity.y, 0f);
    }
  }
  public void Teleport(Vector3 position)
  {

    rb.linearVelocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;
    rb.position = position;
  }

  public void Init(float speed)
  {
    this.speed = speed;
  }

  void OnDisable()
  {
    if (!playerInput) return;

  }
}