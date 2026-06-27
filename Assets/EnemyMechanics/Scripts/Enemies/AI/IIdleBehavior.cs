using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public interface IIdleBehavior
    {
        Vector3 Tick(IEnemyContext enemy);
    }
}