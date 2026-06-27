using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public class ChaseBehavior : IReactionBehavior
    {
        public Vector3 Tick(IEnemyContext enemy, Transform player)
        {
            Vector3 direction = (player.position - enemy.Position);
            direction.y = 0;
            
            return direction.normalized;    
        }
    }
}