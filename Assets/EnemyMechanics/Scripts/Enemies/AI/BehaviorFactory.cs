
namespace EnemyMechanics.Enemies.AI
{
    public class BehaviorFactory
    {
        public IBehavior CreateIdle(IdleBehaviorTypes type, BehaviorContext context) => type switch
        {
            IdleBehaviorTypes.Stand => new StandBehavior(),
            IdleBehaviorTypes.Patrol => new PatrolBehavior(context.Self, context.Mover, context.PatrolPoints),
            IdleBehaviorTypes.RandomWalk => new RandomBehavior(context.Mover),
            _ => new StandBehavior(),
        };
        
        public IBehavior CreateReaction(ReactionBehaviorTypes type, BehaviorContext context) => type switch
        {
            ReactionBehaviorTypes.Chase => new ChaseBehavior(context.Self, context.Target, context.Mover),
            ReactionBehaviorTypes.Flee => new FleeBehavior(context.Self, context.Target, context.Mover),
            ReactionBehaviorTypes.Die => new DieBehavior(context.Killable),
            _ => new ChaseBehavior(context.Self, context.Target, context.Mover),
        };
    }
}