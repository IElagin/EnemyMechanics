using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public class StandBehavior : IIdleBehavior
    {
        public Vector3 Tick(IEnemyContext enemy)
        {
            return Vector3.zero;
        }
    }
}