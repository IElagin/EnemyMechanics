using System.Collections.Generic;
using UnityEngine;
using EnemyMechanics.Enemies;
using EnemyMechanics.Enemies.AI;
using EnemyMechanics.Playing;

namespace EnemyMechanics.Spawning
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawnPoints;

        private readonly IdleBehaviorFactory _idleFactory = new IdleBehaviorFactory();
        private readonly ReactionBehaviorFactory _reactionFactory = new ReactionBehaviorFactory();

        public void Spawn(Player player)
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                Enemy enemy = Instantiate(spawnPoint.EnemyPrefab, spawnPoint.transform.position, Quaternion.identity);

                IIdleBehavior idleBehavior = _idleFactory.Create(spawnPoint.IdleBehavior, spawnPoint.PatrolPoints);
                IReactionBehavior reactionBehavior = _reactionFactory.Create(spawnPoint.ReactionBehavior);

                enemy.Initialize(idleBehavior, reactionBehavior);
                enemy.Initialize(player);
            }
        }
    }
}