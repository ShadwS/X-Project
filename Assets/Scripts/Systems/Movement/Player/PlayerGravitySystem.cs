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
                var velocity = controller.velocity;
                var gravityForce = playerJumpComponent.GravityForce;

                velocity.y = controller.isGrounded ? -1 : velocity.y - gravityForce * Time.deltaTime;

                controller.Move(velocity * Time.deltaTime);
            }
        }
    }
}