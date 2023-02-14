using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformController : Part
{
    [SerializeField] private float sensitivity = 100f;
    private PlayerInput playerInput;
    private Vector2 inputPosition;
    private Vector2 lastInputPosition;

    public new void Awake(){
        base.Awake();

        playerInput = GetComponent<PlayerInput>();
    }

    public void start(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (root.model.gameModel.status == GameModel.GameStatus.NOTSTARTED)
            {
                root.model.gameModel.startGame();
            }
            if (playerInput.currentControlScheme == "Touchscreen")
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

    public void FixedUpdate()
    {
        if (root.model.gameModel.status != GameModel.GameStatus.RUNNING)
        {
            return;
        }
        if (playerInput.currentControlScheme == "Touchscreen")
        {
            Vector2 newVelocity = inputPosition - lastInputPosition;
            newVelocity *= sensitivity;
            root.model.platformModel.rb.velocity = newVelocity;
            lastInputPosition = inputPosition;
        }
        else
        {
            root.model.platformModel.rb.MovePosition(inputPosition);
        }
    }
}