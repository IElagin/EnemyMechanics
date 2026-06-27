namespace EnemyMechanics.Enemies.AI
{
    public class ReactionBehaviorFactory
    {
        public IReactionBehavior Create(ReactionBehaviorTypes type) => type switch
        {
            ReactionBehaviorTypes.Chase => new ChaseBehavior(),
            ReactionBehaviorTypes.Flee => new FleeBehavior(),
            ReactionBehaviorTypes.Die => new DieBehavior(),
            _ => new ChaseBehavior(),
        };
    }
}