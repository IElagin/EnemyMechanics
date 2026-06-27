using System.Collections.Generic;
using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public class IdleBehaviorFactory
    {
        public IIdleBehavior Create(IdleBehaviorTypes type, IReadOnlyList<Transform> patrolPoints) => type switch
        {
            IdleBehaviorTypes.Stand => new StandBehavior(),
            IdleBehaviorTypes.Patrol => new PatrolBehavior(patrolPoints),
            IdleBehaviorTypes.RandomWalk => new RandomBehavior(),
            _ => new StandBehavior(),
        };
    }
}