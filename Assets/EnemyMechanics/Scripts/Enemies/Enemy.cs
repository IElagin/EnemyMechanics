using EnemyMechanics.Enemies.AI;
using UnityEngine;

namespace EnemyMechanics.Enemies
{
    public class Enemy : MonoBehaviour, IKillable
    {
        private const float AgroRadius = 6f;
        private const float IdleRadius = 9f;
        
        [SerializeField] private ParticleSystem _dieVFXPrefab;
        
        private IBehavior _idleBehavior;
        private IBehavior _reactionBehavior;
        private IBehavior _currentBehavior;
        
        private Transform _player;
        private bool _isAgro;
        
        public void Initialize(IBehavior idleBehavior, IBehavior reactionBehavior, Transform player)
        {
            _idleBehavior = idleBehavior;
            _reactionBehavior = reactionBehavior;
            _currentBehavior = idleBehavior;
            _player = player;
        }
        
        private void Update()
        {
            UpdateAgro();
            
            _currentBehavior = _isAgro ? _reactionBehavior : _idleBehavior;
            _currentBehavior.Tick(Time.deltaTime);
        }

        private void UpdateAgro()
        {
            Vector3 toPlayer = _player.transform.position - transform.position;
            toPlayer.y = 0;
            float sqr = toPlayer.sqrMagnitude;

            if (!_isAgro && sqr <= AgroRadius * AgroRadius)
                _isAgro = true;
            else if (_isAgro && sqr >= IdleRadius * IdleRadius)
                _isAgro = false;
        }
        
        public void Die()
        {
            Instantiate(_dieVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}