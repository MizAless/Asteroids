using System;

public class DefaultGun
{
    protected readonly Transformable _shootPoint;

    public DefaultGun(Transformable shootPoint)
    {
        _shootPoint = shootPoint;
    }

    public virtual bool CanShoot() => true;

    public event Action<Bullet> Shot;

    public void Shoot()
    {
        if (CanShoot() == false)
            throw new InvalidOperationException();

        Bullet bullet = GetBullet();
        Shot?.Invoke(bullet);
    }

    protected virtual Bullet GetBullet() => new DefaultBullet(_shootPoint.Position, _shootPoint.Forward, Config.DefaultBulletSpeed);
}
