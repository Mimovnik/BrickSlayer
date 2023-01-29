using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private GameController gameController;
    private Rigidbody2D rb;
    private Vector2 inputPosition;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindObjectOfType<GameController>();
        if (gameController == null)
        {
            throw new UnityException("Add GameController to this scene");
        }
    }

    public void start(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!gameController.isGameStarted())
            {
                gameController.startGame();
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
        if (!gameController.isGameStarted())
        {
            return;
        }
        rb.MovePosition(inputPosition);
    }
}