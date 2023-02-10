using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private GameController gameController;
    private Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindObjectOfType<GameController>();
        if (gameController == null)
        {
            throw new UnityException("Add GameController to this scene");
        }
    }


}
