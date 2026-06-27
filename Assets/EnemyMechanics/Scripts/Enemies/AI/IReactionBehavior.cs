using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public interface IReactionBehavior
    {
        Vector3 Tick(IEnemyContext enemy, Transform player);
    }
}