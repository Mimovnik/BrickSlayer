using UnityEngine;
using TMPro;

public class TouchCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text touchCounterDisplay;
    private int touches = 0;

    public void Update()
    {
        if (touchCounterDisplay == null)
        {
            return;
        }
        touchCounterDisplay.SetText("Touches: " + touches);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Ball"))
        {
            touches++;
        }
    }
}
