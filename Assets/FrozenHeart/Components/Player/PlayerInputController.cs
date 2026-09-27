using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{

  private PlayerInput inputActions;
  private PlayerMovement movement;
  public Vector2 MoveInput { get; private set; }
  public event Action OnInteractPressed;
  public event Action<bool> OnMoveChanged;
  public Vector2 MousePosition { get; private set; }

  public bool isMoving = false;

  void Awake()
  {
    inputActions = new PlayerInput();
    movement = GetComponent<PlayerMovement>();
  }

  void Update()
  {
    if (movement == null || inputActions == null) return;
    //MoveInput = inputActions.Player.Move.ReadValue<Vector2>();
    MousePosition = Mouse.current.position.ReadValue();

  }
  public void InteractPressed(InputAction.CallbackContext context)
  {

    OnInteractPressed?.Invoke();
  }
  public void MoveChanged(InputAction.CallbackContext context)
  {
    isMoving = !context.canceled;
  }


  private void OnEnable()
  {

    inputActions.Player.Enable();
    inputActions.Player.Interact.performed += InteractPressed;
    inputActions.Player.Move.started += MoveChanged;
    inputActions.Player.Move.canceled += MoveChanged;

  }
  private void OnDisable()
  {

    inputActions.Player.Interact.performed -= InteractPressed;
    inputActions.Player.Move.started -= MoveChanged;
    inputActions.Player.Move.canceled -= MoveChanged;
    inputActions.Player.Disable();
  }
}