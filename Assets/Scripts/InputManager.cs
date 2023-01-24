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

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    public void move(InputAction.CallbackContext context)
    {
        movementInput = Vector2.zero;
        if (context.performed)
        {
            movementInput = context.ReadValue<Vector2>();
            if(!gameController.isGameStarted()){
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
        if (doDash)
        {
            rb.AddForce(movementInput * dashMultiplier, ForceMode2D.Force);
        }

        rb.AddForce(movementInput * moveMultiplier, ForceMode2D.Force);
        doDash = false;
    }
}