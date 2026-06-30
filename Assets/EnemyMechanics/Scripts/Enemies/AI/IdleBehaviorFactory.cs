using System.Collections.Generic;
using EnemyMechanics.Movement;
using JetBrains.Annotations;
using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public class IdleBehaviorFactory
    {
        public IBehavior Create(IdleBehaviorTypes type, Transform self, Mover mover, [CanBeNull] IReadOnlyList<Transform> patrolPoints) => type switch
        {
            IdleBehaviorTypes.Stand => new StandBehavior(),
            IdleBehaviorTypes.Patrol => new PatrolBehavior(self, mover, patrolPoints),
            IdleBehaviorTypes.RandomWalk => new RandomBehavior(mover),
            _ => new StandBehavior(),
        };
    }
}