using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInput : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchTapAction;
    private InputAction touchHoldAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions["TouchPosition"];
        touchTapAction = playerInput.actions["Tap"];
        touchHoldAction = playerInput.actions["Hold"];

    }

    private void OnEnable()
    {
        touchTapAction.performed += TouchPressed;
        touchHoldAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchTapAction.performed -= TouchPressed;
        touchHoldAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
        position.z = player.transform.position.z;
        player.transform.position = position;
    }

}