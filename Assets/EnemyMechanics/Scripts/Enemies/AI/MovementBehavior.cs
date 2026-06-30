using EnemyMechanics.Core;
using EnemyMechanics.Movement;
using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public abstract class MovementBehavior : IBehavior
    {
        private readonly Mover _mover;
        
        protected MovementBehavior(Mover mover)
        {
            _mover = mover;
        }

        public void Tick(float deltaTime)
        {
            Vector3 direction = GetDirection();                                                                                                                                                                                                                                      
            direction.y = 0;                                                                                                                                                                                                                                                                                     
                                                                                                                                                                                                                                                                                                                   
            if (direction.sqrMagnitude <= ConfigData.MovementDeadZone * ConfigData.MovementDeadZone)                                                                                                                                                                                                             
                return;                                                                                                                                                                                                                                                                                          
                                                                                                                                                                                                                                                                                                                   
            direction.Normalize();                                                                                                                                                                                                                                                                               
            _mover.MoveTo(direction);                                                                                                                                                                                                                                                                            
            _mover.RotateTo(direction);    
        }
        
        protected abstract Vector3 GetDirection();
    }
}