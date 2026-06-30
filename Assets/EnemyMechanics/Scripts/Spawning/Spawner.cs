using System.Collections.Generic;
using UnityEngine;
using EnemyMechanics.Enemies;
using EnemyMechanics.Enemies.AI;
using EnemyMechanics.Movement;
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
                Transform self = enemy.transform;
                Mover mover = enemy.GetComponent<Mover>();
                Transform target = player.transform;
                
                IBehavior idleBehavior = _idleFactory.Create(spawnPoint.IdleBehavior, self, mover, spawnPoint.PatrolPoints);
                IBehavior reactionBehavior = _reactionFactory.Create(spawnPoint.ReactionBehavior, self, target, mover, enemy);

                enemy.Initialize(idleBehavior, reactionBehavior, target);
            }
        }
    }
}