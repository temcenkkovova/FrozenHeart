using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{

  private PlayerInput inputActions;
  private PlayerMovement movement;
  public Vector2 MoveInput { get; private set; }
  public event Action OnInteractPressed;

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
  public void InteractPressed(InputAction.CallbackContext context)
  {

    OnInteractPressed?.Invoke();
  }

  private void OnEnable()
  {
    inputActions.Player.Enable();
    inputActions.Player.Interact.performed += InteractPressed;

  }
  private void OnDisable()
  {
    inputActions.Player.Interact.performed -= InteractPressed;
    inputActions.Player.Disable();
  }
}