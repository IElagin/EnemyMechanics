using UnityEngine;

namespace EnemyMechanics.Enemies
{
    public interface IEnemyContext
    {
        Vector3 Position { get; }
        void Die();
    }
}