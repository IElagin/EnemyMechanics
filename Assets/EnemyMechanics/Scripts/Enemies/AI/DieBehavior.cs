using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public class DieBehavior : IReactionBehavior
    {
        public Vector3 Tick(IEnemyContext enemy, Transform player)
        {
            enemy.Die();
            return Vector3.zero;
        }
    }
}