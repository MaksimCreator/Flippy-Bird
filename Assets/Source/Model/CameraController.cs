using UnityEngine;

public class CameraController
{
    private readonly Camera _camera;
    private readonly IPosition _bird;
    private readonly float _xOffset;

    public CameraController(Camera camera, Bird bird, float xOffset)
    {
        _camera = camera;
        _bird = bird;
        _xOffset = xOffset;
    }

    public void Move()
        => _camera.transform.position = new Vector3(_bird.PositionX - _xOffset, _camera.transform.position.y, _camera.transform.position.z);
}
