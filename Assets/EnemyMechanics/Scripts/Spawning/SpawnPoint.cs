using System.Collections.Generic;
using EnemyMechanics.Enemies;
using EnemyMechanics.Enemies.AI;
using UnityEngine;

namespace EnemyMechanics.Spawning
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private IdleBehaviorTypes _idleBehavior;
        [SerializeField] private ReactionBehaviorTypes _reactionBehavior;
        [SerializeField] private List<Transform> _patrolPoints;
        [SerializeField] private Enemy _enemyPrefab;
        
        public IdleBehaviorTypes IdleBehavior => _idleBehavior;
        public ReactionBehaviorTypes ReactionBehavior => _reactionBehavior;
        public List<Transform> PatrolPoints => _patrolPoints;
        public Enemy EnemyPrefab => _enemyPrefab;
    }
}