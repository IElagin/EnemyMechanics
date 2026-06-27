using EnemyMechanics.Core;
using EnemyMechanics.Enemies.AI;
using EnemyMechanics.Playing;
using EnemyMechanics.Movement;
using UnityEngine;

namespace EnemyMechanics.Enemies
{
    public class Enemy : MonoBehaviour, IEnemyContext
    {
        private const float AgroRadius = 6f;
        private const float IdleRadius = 9f;
        
        [SerializeField] private ParticleSystem _dieVFXPrefab;
        
        private Mover _mover;
        private IIdleBehavior _idleBehavior;
        private IReactionBehavior _reactionBehavior;
        
        private Vector3 _direction;
        private Player _player;
        private bool _isAgro;
        
        public Vector3 Position => transform.position;
        
        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }
        
        public void Initialize(IIdleBehavior idleBehavior, IReactionBehavior reactionBehavior)
        {
            _idleBehavior = idleBehavior;
            _reactionBehavior = reactionBehavior;
        }
        
        public void Initialize(Player player)
        {
           _player = player;
        }

        private void Update()
        {
            UpdateAgro();
            
            if (_isAgro)
                _direction = _reactionBehavior.Tick(this, _player.transform);
            else
                _direction = _idleBehavior.Tick(this);
            
            if (_direction.magnitude <= ConfigData.MovementDeadZone)
                return;
            
            _mover.MoveTo(_direction);
            _mover.RotateTo(_direction);
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