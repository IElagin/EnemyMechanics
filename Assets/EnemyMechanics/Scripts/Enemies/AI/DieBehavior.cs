
namespace EnemyMechanics.Enemies.AI
{
    public class DieBehavior : IBehavior
    {
        private readonly IKillable _target;

        public DieBehavior(IKillable target)
        {
            _target = target;
        }

        public void Tick(float deltaTime) => _target.Die();
    }
}