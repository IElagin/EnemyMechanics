using EnemyMechanics.Movement;
using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public class ChaseBehavior : MovementBehavior
    {
        private readonly Transform _self;
        private readonly Transform _target;
        
        public ChaseBehavior(Transform self, Transform target, Mover mover) : base(mover)
        {
            _self = self;
            _target = target;
        }

        protected override Vector3 GetDirection() => _target.position - _self.position;
    }
}