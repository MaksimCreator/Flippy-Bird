using UnityEngine;

public class Bird : IPosition
{
    private readonly Rigidbody2D _rigidbody;
    private readonly float _tapForce;
    private readonly float _maxRotation;
    private readonly float _minRotation;
    private readonly float _speedRotation;

    public float PositionX => _rigidbody.position.x;

    public Bird(Rigidbody2D rigidbodyBird, float tapForce,float maxRotation,float minRotation,float SpeedRotation)
    {
        _rigidbody = rigidbodyBird;
        _tapForce = tapForce;
        _maxRotation = maxRotation;
        _minRotation = minRotation;
        _speedRotation = SpeedRotation;
    }

    public void Move(float speed,float delta)
    {
        _rigidbody.velocity = new Vector2(speed, _rigidbody.velocity.y);
        _rigidbody.transform.rotation = Quaternion.Lerp(_rigidbody.transform.rotation, Quaternion.Euler(0, 0, _minRotation), delta * _speedRotation);
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(new Vector2(0, _tapForce), ForceMode2D.Force);
        _rigidbody.transform.rotation = Quaternion.Euler(new Vector3(0, 0, _maxRotation));

        AllMusicGame.Singleton.PLayWingMusic();
    }
}
