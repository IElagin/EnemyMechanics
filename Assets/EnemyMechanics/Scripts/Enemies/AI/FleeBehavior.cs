using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public class FleeBehavior : IReactionBehavior
    {
        public Vector3 Tick(IEnemyContext enemy, Transform player)
        {
            Vector3 direction = (enemy.Position - player.position);
            direction.y = 0;
            
            return direction.normalized;
        }
    }
}