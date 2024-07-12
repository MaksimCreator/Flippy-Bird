using UnityEngine.InputSystem;

public class InputRouter
{
    private readonly InputGame _input = new();
    private readonly BirdMove _move;
    private readonly CameraController _cameraController;

    public InputRouter(BirdMove move,CameraController cameraController)
    {
        _move = move;
        _cameraController = cameraController;
    }

    public void OnEnable()
    {
        _input.Enable();

        _input.Bird.Moveming.performed += Jump; 
    }

    public void OnDisable()
    {
        _input.Disable();

        _input.Bird.Moveming.performed -= Jump;
    }

    public void Update(float deltatime)
    { 
        _move.Update(deltatime);
        _cameraController.Move();
    }

    private void Jump(InputAction.CallbackContext context)
        => _move.Jump();
}