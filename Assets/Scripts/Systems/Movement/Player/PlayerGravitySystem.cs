using Leopotam.Ecs;
using UnityEngine;

namespace Core.Movement
{
    public sealed class PlayerGravitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<CharacterControllerComponent, PlayerJumpComponent> _playerFilter = null;

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                ref var characterControllerComponent = ref _playerFilter.Get1(i);
                ref var playerJumpComponent = ref _playerFilter.Get2(i);

                var controller = characterControllerComponent.CharacterController;
                var isGround = controller.isGrounded;

                ref var y = ref playerJumpComponent.VelocityY;
                var baseGravity = playerJumpComponent.BaseGravity;

                if (isGround && y < baseGravity)
                {
                    y = baseGravity;
                }
                else
                {
                    y -= playerJumpComponent.GravityForce * Time.deltaTime;
                }
            }
        }
    }
}