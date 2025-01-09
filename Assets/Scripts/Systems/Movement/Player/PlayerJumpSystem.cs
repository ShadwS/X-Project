using Leopotam.Ecs;

namespace Core.Movement
{
    public sealed class PlayerJumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerJumpComponent, JumpEvent> _playerFilter = null;

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                ref var playerJumpComponent = ref _playerFilter.Get1(i);
                ref var velocityY = ref playerJumpComponent.VelocityY;
                velocityY = playerJumpComponent.JumpForce;
            }
        }
    }
}