using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private float speed;
  private PlayerInputController playerInput;
  private Rigidbody rb;

  private Vector3 movement;

  public bool MovementBlocked { get; private set; }
  void Awake()
  {
    playerInput = GetComponent<PlayerInputController>();
    rb = GetComponent<Rigidbody>();
  }
  void Update()
  {
    if (MovementBlocked)
    {
      movement = Vector3.zero;
      return;
    }
    float horizontal = playerInput.MoveInput.x;
    float vertical = playerInput.MoveInput.y;

    movement = new Vector3(horizontal, 0f, vertical).normalized;
  }

  void FixedUpdate()
  {
    Vector3 velocity = rb.linearVelocity;
    Vector3 direction = MovementBlocked ? Vector3.zero : movement;

    rb.linearVelocity = new Vector3(direction.x * speed, velocity.y, direction.z * speed);
  }
  public void SetMovementBlocked(bool blocked)
  {
    MovementBlocked = blocked;
    movement = Vector3.zero;

    if (blocked)
    {
      // Останавливаем ходьбу, но сохраняем гравитацию.
      Vector3 velocity = rb.linearVelocity;
      rb.linearVelocity = new Vector3(0f, velocity.y, 0f);
    }
  }
  public void Teleport(Vector3 position)
  {
    movement = Vector3.zero;
    rb.linearVelocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;
    rb.position = position;
  }

  public void Init(float speed)
  {
    this.speed = speed;
  }
}