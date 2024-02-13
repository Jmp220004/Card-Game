using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputBroadcaster : MonoBehaviour
{
    public bool IsTapPressed { get; private set; } = false;

    [SerializeField] private GameObject player;
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchTapAction;
    private InputAction touchHoldAction;
    //ToDO add other input events here

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions["TouchPosition"];
        touchTapAction = playerInput.actions["Tap"];
        touchHoldAction = playerInput.actions["Hold"];

    }


    
    private void Update()
    {
        // Put Input/Detection here. This Code 
        // is just for simple example and does not account
        // for new input system setup
        if (touchTapAction.WasPerformedThisFrame() || touchHoldAction.WasPerformedThisFrame())
        {
            IsTapPressed = true;
        }
        else if(touchTapAction.WasReleasedThisFrame() || touchHoldAction.WasReleasedThisFrame())
        {
            IsTapPressed = false;
        }
    }

}
