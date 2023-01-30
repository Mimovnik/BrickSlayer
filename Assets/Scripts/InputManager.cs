using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float sensitivity = 100f;
    [SerializeField] private PlayerInput playerInput;
    private GameController gameController;
    private Rigidbody2D rb;
    private Vector2 inputPosition;
    private Vector2 lastInputPosition;

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
            lastInputPosition = Vector2.zero;
            inputPosition = Vector2.zero;
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
        if (playerInput.currentControlScheme == "Touchscreen")
        {
            Vector2 newVelocity = inputPosition - lastInputPosition;
            newVelocity *= sensitivity;
            rb.velocity = newVelocity;
            lastInputPosition = inputPosition;
            return;
        }
        rb.MovePosition(inputPosition);
    }
}
