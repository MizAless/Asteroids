using UnityEngine.UI;
using UnityEngine;

public class ShipDebugUIPresenter : MonoBehaviour
{
    [SerializeField] private Root _root;

    [SerializeField] private Text _positionLabel;
    [SerializeField] private Text _rotationLabel;
    [SerializeField] private Text _speedLabel;
    [SerializeField] private Text _laserBulletsLabel;
    [SerializeField] private Text _laserRollbackLabel;


    public void OnEnableCustom()
    {
        _root.LaserGun.Shot += OnLaserGunShot;
        _root.LaserGun.ShotAdd += OnLaserGunShotAdd;

        UpdateLasersCount();
    }

    private void OnDisable()
    {
        _root.LaserGun.Shot -= OnLaserGunShot;
        _root.LaserGun.ShotAdd -= OnLaserGunShotAdd;
    }


    private void Update()
    {
        _positionLabel.text = $"Position: {_root.Ship.Position}";
        _rotationLabel.text = $"Rotation: {Mathf.RoundToInt(_root.Ship.Rotation)}�";
        _speedLabel.text = $"Speed: {Mathf.RoundToInt(_root.Ship.Acceleration.magnitude * 10000)}";
        _laserRollbackLabel.text = $"To Rollback: {(_root.LaserGunRollback.Cooldown - _root.LaserGunRollback.AccumulatedTime):0.0}";
    }

    private void OnLaserGunShot(Bullet bullet)
    {
        UpdateLasersCount();
    }

    private void OnLaserGunShotAdd()
    {
        UpdateLasersCount();
    }

    private void UpdateLasersCount()
    {
        _laserBulletsLabel.text = $"Lasers: {_root.LaserGun.Bullets} / {_root.LaserGun.MaxBullets}";
    }
}
