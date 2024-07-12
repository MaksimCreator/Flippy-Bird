using System;

public class BirdMove
{
    private readonly Bird _bird;
    private float _speed;

    public BirdMove(Bird bird,float speed)
    {
        _bird = bird;
        _speed = speed;
    }

    public void Jump()
        =>  _bird.Jump();

    public void Update(float delta)
    {
        if (delta <= 0)
            throw new InvalidOperationException(nameof(delta));

        _bird.Move(_speed,delta);
    }
}
