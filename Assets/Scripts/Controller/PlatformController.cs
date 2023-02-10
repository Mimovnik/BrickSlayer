using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformController : Part
{
    private Vector2 inputPosition;
    private Vector2 lastInputPosition;

    public void start(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!root.model.gameModel.gameStarted)
            {
                root.controller.gameController.startGame();
            }
            if (root.model.platformModel.playerInput.currentControlScheme == "Touchscreen")
            {
                lastInputPosition = Vector2.zero;
                inputPosition = Vector2.zero;
            }
        }
    }

    public void reposition(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputPosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        }
    }

    public void OnCollisionWithBall()
    {
        root.model.platformModel.ballTouches++;
    }

    public void FixedUpdate()
    {
        if (!root.model.gameModel.gameStarted)
        {
            return;
        }
        if (root.model.platformModel.playerInput.currentControlScheme == "Touchscreen")
        {
            Vector2 newVelocity = inputPosition - lastInputPosition;
            newVelocity *= root.model.platformModel.sensitivity;
            root.view.platformView.rb.velocity = newVelocity;
            lastInputPosition = inputPosition;
        }
        else
        {
            root.view.platformView.rb.MovePosition(inputPosition);
        }
    }
}