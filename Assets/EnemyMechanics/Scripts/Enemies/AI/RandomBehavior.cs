using EnemyMechanics.Movement;
using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public class RandomBehavior : IBehavior
    {
        private const float ChangeInterval = 1f;
        
        private Vector3 _direction;
        private float _timer;
        private readonly Mover _mover;

        public RandomBehavior(Mover mover)
        {
            _mover = mover;
        }
        
        public void Tick(float deltaTime)
        {
            _timer -= deltaTime;

            if (_timer <= 0)
            {
                _direction = GetRandomDirection();
                _timer = ChangeInterval;
            }
            
            _mover.MoveTo(_direction);
            _mover.RotateTo(_direction);
        }

        private Vector3 GetRandomDirection()
        {
            Vector3 random = Random.insideUnitSphere;
            random.y = 0;
            
            return random.normalized;
        }
    }
}