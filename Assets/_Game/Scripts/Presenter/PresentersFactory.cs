using UnityEngine;

public class PresentersFactory : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Presenter _laserGunBulletTemplate;
    [SerializeField] private Presenter _defaultGunBulletTemplate;
    [SerializeField] private Presenter _asteroidTemplate;
    [SerializeField] private Presenter _asteroidPartTemplate;
    [SerializeField] private Presenter _ufoTemplate;

    private Score _score;

    public void Init(Score score)
    {
        _score = score;
    }

    public void CreateBullet(Bullet bullet)
    {
        if (bullet is LaserGunBullet)
            CreatePresenter(_laserGunBulletTemplate, bullet);
        else
            CreatePresenter(_defaultGunBulletTemplate, bullet);
    }

    public void CreateAsteroidParts(AsteroidPresenter asteroid)
    {
        for (int i = 0; i < 4; i++)
            CreatePresenter(_asteroidPartTemplate, asteroid.Model.CreatePart());
    }

    public void CreateUfo(Ufo ufo)
    {
        Presenter presenter = CreatePresenter(_ufoTemplate, ufo);
    }

    public void CreateAsteroid(Asteroid asteroid)
    {
        AsteroidPresenter presenter = CreatePresenter(_asteroidTemplate, asteroid) as AsteroidPresenter;
        presenter.Init(this);
    }

    private Presenter CreatePresenter(Presenter template, Transformable model)
    {
        Presenter presenter = Instantiate(template);
        presenter.Init(model, _camera);

        presenter.Destroying += _score.OnKill;
        presenter.Destroyed += OnDestroyedPresenter;

        return presenter;
    }

    private void OnDestroyedPresenter(Presenter presenter)
    {
        presenter.Destroying -= _score.OnKill;
        presenter.Destroyed -= OnDestroyedPresenter;
    }
}