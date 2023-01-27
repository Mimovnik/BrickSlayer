using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float moveMultiplier = 10f;
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

    public void reposition(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            inputPosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            if (!gameController.isGameStarted())
            {
                gameController.startGame();
            }
        }
    }

    public void FixedUpdate()
    {
        Vector2 newPos = rb.position;
        newPos.x = inputPosition.x;
        rb.position = newPos;
    }
}