using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{

  private PlayerInput inputActions;
  private PlayerMovement movement;
  public Vector2 MoveInput { get; private set; }
  public event Action OnInteractPressed;
  public Vector2 MousePosition { get; private set; }

  void Awake()
  {
    inputActions = new PlayerInput();
    movement = GetComponent<PlayerMovement>();
  }

  void Update()
  {
    if (movement == null || inputActions == null) return;
    MoveInput = inputActions.Player.Move.ReadValue<Vector2>();
    MousePosition = Mouse.current.position.ReadValue();

  }
  public void InteractPressed(InputAction.CallbackContext context)
  {
    Debug.Log("sa");
    OnInteractPressed?.Invoke();
  }

  private void OnEnable()
  {
    Debug.Log("enable");
    inputActions.Player.Enable();
    inputActions.Player.Interact.performed += InteractPressed;

  }
  private void OnDisable()
  {
    Debug.Log("disable");
    inputActions.Player.Interact.performed -= InteractPressed;
    inputActions.Player.Disable();
  }
}