using Leopotam.Ecs;
using UnityEngine;

namespace Core.Movement
{
    public sealed class PlayerButtonJumpPressSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterControllerComponent, PlayerJumpComponent> _playerFilter = null;

        public void Run()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var i in _playerFilter)
                {
                    ref var entity = ref _playerFilter.GetEntity(i);
                    var controller = entity.Get<CharacterControllerComponent>().CharacterController;
                    if (controller.isGrounded)
                    {
                        entity.Get<JumpEvent>();
                    }
                }
            }
        }
    }
}