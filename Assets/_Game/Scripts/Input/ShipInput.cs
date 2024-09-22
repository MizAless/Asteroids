using System;
using UnityEngine;

public class ShipInput
{
    private static string Horizontal = nameof(Horizontal);
    private static string Vertical = nameof(Vertical); 

    public event Action Moved;
    public event Action FirstGunFired;
    public event Action SecondGunFired;
    public event Action<float> Rotated;

    public void Update()
    {
        float vertical = Input.GetAxisRaw(Vertical);
        float horizontal = Input.GetAxisRaw(Horizontal);

        if (vertical > 0)
            Moved?.Invoke();

        if (horizontal != 0)
            Rotated?.Invoke(horizontal);

        if (Input.GetButtonDown("Fire1"))
            FirstGunFired?.Invoke();

        if (Input.GetButtonDown("Fire2"))
            SecondGunFired?.Invoke();
    }
}
