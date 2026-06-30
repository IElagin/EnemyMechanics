using EnemyMechanics.Movement;
using UnityEngine;

namespace EnemyMechanics.Enemies.AI
{
    public class ReactionBehaviorFactory
    {
        public IBehavior Create(ReactionBehaviorTypes type, Transform self, Transform target, Mover mover, IKillable killable) => type switch
        {
            ReactionBehaviorTypes.Chase => new ChaseBehavior(self, target, mover),
            ReactionBehaviorTypes.Flee => new FleeBehavior(self, target, mover),
            ReactionBehaviorTypes.Die => new DieBehavior(killable),
            _ => new ChaseBehavior(self, target, mover),
        };
    }
}