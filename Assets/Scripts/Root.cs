using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private Model _model;
    [SerializeField] private View _view;
    [SerializeField] private Controller _controller;

    public Model model => _model;
    public View view => _view;
    public Controller controller => _controller;
}
