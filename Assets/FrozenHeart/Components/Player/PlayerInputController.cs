using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

  private PlayerInput inputActions;
  private PlayerMovement movement;
  public Vector2 MoveInput { get; private set; }

  void Awake()
  {
    inputActions = new PlayerInput();
    movement = GetComponent<PlayerMovement>();
  }

  void Update()
  {
    if (movement == null || inputActions == null) return;
    MoveInput = inputActions.Player.Move.ReadValue<Vector2>();

  }

  private void OnEnable()
  {
    inputActions.Player.Enable();

  }
  private void OnDisable()
  {
    inputActions.Player.Disable();
  }
}