using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public class RandomBehavior : IIdleBehavior
    {
        private const float ChangeInterval = 1f;
        
        private Vector3 _direction;
        private float _timer;
        
        public Vector3 Tick(IEnemyContext enemy)
        {
            _timer -= Time.deltaTime;
            
            if (_timer <= 0)
            {
                _direction = GetRandomDirection();
                _timer = ChangeInterval;
            }
            
            return _direction;
        }

        private Vector3 GetRandomDirection()
        {
            Vector3 random = Random.insideUnitSphere;
            random.y = 0;
            
            return random.normalized;
        }
    }
}