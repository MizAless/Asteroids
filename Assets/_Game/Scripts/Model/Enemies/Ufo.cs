using UnityEngine;

public class Ufo : Enemy
{
    private readonly float _speed;
    private readonly Transformable _target;

    public Ufo(Vector2 position, float speed, Transformable target) : base(position, 0)
    {
        _speed = speed;
        _target = target;
    }

    public override void Update(float deltaTime)
    {
        Vector2 nextPosition = Vector2.MoveTowards(Position, _target.Position, _speed * deltaTime);
        MoveTo(nextPosition);
        LookAt(_target.Position);
    }

    private void LookAt(Vector2 point)
    {
        Rotate(Vector2.SignedAngle(Quaternion.Euler(0, 0, Rotation) * Vector3.up, (Position - point)));
    }
}