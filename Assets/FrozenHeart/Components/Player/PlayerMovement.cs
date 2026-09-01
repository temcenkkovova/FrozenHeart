using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private float speed;
  private PlayerInputController playerInput;
  private Rigidbody rb;

  private Vector3 movement;


  void Awake()
  {
    playerInput = GetComponent<PlayerInputController>();
    rb = GetComponent<Rigidbody>();
  }
  void Update()
  {
    float horizontal = playerInput.MoveInput.x;
    float vertical = playerInput.MoveInput.y;

    movement = new Vector3(horizontal, 0f, vertical).normalized;
  }

  void FixedUpdate()
  {
    Vector3 velocity = rb.linearVelocity;


    rb.linearVelocity = new Vector3(movement.x * speed, velocity.y, movement.z * speed);
  }


  public void Init(float speed)
  {
    this.speed = speed;
  }
}