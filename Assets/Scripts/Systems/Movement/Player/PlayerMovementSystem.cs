using Leopotam.Ecs;
using UnityEngine;

namespace Core.Movement
{
    public sealed class PlayerMovementSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<CharacterControllerComponent, PlayerSpeedComponent,
            PlayerJumpComponent> _playerFilter = null;

        private MyInput _inputs;

        public void Init() => _inputs = new MyInput();

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                ref var characterControllerComponent = ref _playerFilter.Get1(i);
                ref var playerSpeedConponent = ref _playerFilter.Get2(i);
                ref var playerJumpComponent = ref _playerFilter.Get3(i);

                var controller =  characterControllerComponent.CharacterController;
                var speed = playerSpeedConponent.Speed;

                var y = playerJumpComponent.VelocityY;

                controller.Move(_inputs.GetDirection(y) * speed * Time.deltaTime);
            }
        }
    }
}