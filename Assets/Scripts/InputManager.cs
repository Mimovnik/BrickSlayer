using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] float moveMultiplier = 10f;
    [SerializeField] float dashMultiplier = 5f;
    private Rigidbody2D rb;
    private Vector2 movementInput = Vector2.zero;
    private bool doDash = false;
    private GameController gameController;
    private Vector2 touchPosition;

    private PlayerInput playerInput;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindObjectOfType<GameController>();
        playerInput = GetComponent<PlayerInput>();
    }

    public void move(InputAction.CallbackContext context)
    {
        movementInput = Vector2.zero;
        if (context.performed)
        {
            movementInput = context.ReadValue<Vector2>();
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
            touchPosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            if (!gameController.isGameStarted())
            {
                gameController.startGame();
            }
        }
    }

    public void dash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            doDash = true;
        }
    }

    public void FixedUpdate()
    {
        if (playerInput.currentControlScheme == "Keyboard")
        {
            if (doDash)
            {
                rb.AddForce(movementInput * dashMultiplier, ForceMode2D.Force);
            }

            rb.AddForce(movementInput * moveMultiplier, ForceMode2D.Force);
            doDash = false;
        }
        else if (playerInput.currentControlScheme == "Touch")
        {
            Vector2 newPos = rb.position;
            newPos.x = touchPosition.x;
            rb.position = newPos;
        }
    }
}