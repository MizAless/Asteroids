using UnityEngine;

public class ShipInputRouter
{
    private Ship _ship;
    private ShipInput _shipInput;

    private DefaultGun _firstGunSlot;
    private DefaultGun _secondGunSlot;

    public ShipInputRouter(Ship ship)
    {
        _shipInput = new ShipInput();
        _ship = ship;
    }

    public void OnEnable()
    {
        _shipInput.Moved += OnMoved;
        _shipInput.Rotated += TryRotate;
        _shipInput.FirstGunFired += OnFirstGunFired;
        _shipInput.SecondGunFired += OnSecondGunFired;
    }

    public void OnDisable()
    {
        _shipInput.Moved -= OnMoved;
        _shipInput.Rotated -= TryRotate;
        _shipInput.FirstGunFired -= OnFirstGunFired;
        _shipInput.SecondGunFired -= OnSecondGunFired;
    }

    public void Update()
    {
        _shipInput.Update();
    }

    public ShipInputRouter BindGunToFirstSlot(DefaultGun gun)
    {
        _firstGunSlot = gun;
        return this;
    }

    public ShipInputRouter BindGunToSecondSlot(DefaultGun gun)
    {
        _secondGunSlot = gun;
        return this;
    }

    private void OnMoved()
    {
        _ship.Accelerate(Time.deltaTime);
    }

    private void OnFirstGunFired()
    {
        TryShoot(_firstGunSlot);
    }

    private void OnSecondGunFired()
    {
        TryShoot(_secondGunSlot);
    }

    private void TryShoot(DefaultGun gun)
    {
        if (gun.CanShoot())
            gun.Shoot();
    }

    private void TryRotate(float direction)
    {
        if (direction != 0)
            _ship.Rotate(direction, Time.deltaTime);
    }

}
