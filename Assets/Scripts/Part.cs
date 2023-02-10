using UnityEngine;

public abstract class Part : MonoBehaviour
{
    protected Root root { get; private set; }

    public void Awake() => root = FindObjectOfType<Root>();
}
