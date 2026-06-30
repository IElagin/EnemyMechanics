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

        private readonly BehaviorFactory _behaviorFactory = new BehaviorFactory();

        public void Spawn(Player player)
        {
            foreach (SpawnPoint spawnPoint in _spawnPoints)
            {
                Enemy enemy = Instantiate(spawnPoint.EnemyPrefab, spawnPoint.transform.position, Quaternion.identity);

                BehaviorContext context = new BehaviorContext(
                    enemy.transform,
                    player.transform,
                    enemy.GetComponent<Mover>(),
                    enemy,
                    spawnPoint.PatrolPoints);
                
                IBehavior idleBehavior = _behaviorFactory.CreateIdle(spawnPoint.IdleBehavior, context);
                IBehavior reactionBehavior = _behaviorFactory.CreateReaction(spawnPoint.ReactionBehavior, context);

                enemy.Initialize(idleBehavior, reactionBehavior, context.Target);
            }
        }
    }
}