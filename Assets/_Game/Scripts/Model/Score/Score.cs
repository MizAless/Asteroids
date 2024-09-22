using System;

public class Score
{
    private readonly EnemyVisitor _enemyVisitor = new EnemyVisitor();

    public int Value => _enemyVisitor.AccumulatedScore;

    public void OnKill(Transformable transformable)
    {
        if (transformable is Enemy enemy)
            _enemyVisitor.Visit(enemy);
    }

    private class EnemyVisitor : IEnemyVisitor
    {
        public int AccumulatedScore { get; private set; }

        public void Visit(Asteroid asteroid)
        {
            AccumulatedScore += 10;
        }

        public void Visit(Ufo ufo)
        {
            AccumulatedScore += 20;
        }

        public void Visit(PartOfAsteroid partOfAsteroid)
        {
            AccumulatedScore += 5;
        }

        public void Visit(Enemy enemy)
        {
            if (enemy is Asteroid asteroid)
            {
                Visit(asteroid);
            }
            else if (enemy is Ufo ufo)
            {
                Visit(ufo);
            }
            else if (enemy is PartOfAsteroid partOfAsteroid)
            {
                Visit(partOfAsteroid);
            }
            else
            {
                throw new ArgumentException("Unknown enemy type");
            }
        }
    }
}