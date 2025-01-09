using Leopotam.Ecs;
using UnityEngine;

namespace Core.Movement
{
    public sealed class PlayerMovementSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<CharacterControllerComponent, PlayerSpeedComponent> _playerFilter = null;

        private MyInput _inputs;

        public void Init()
        {
            _inputs = new MyInput();
        }

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                ref var characterControllerComponent = ref _playerFilter.Get1(i);
                ref var playerSpeedConponent = ref _playerFilter.Get2(i);

                ref var controller = ref characterControllerComponent.CharacterController;
                var speed = playerSpeedConponent.Speed;

                controller.Move(_inputs.GetDirection() * speed * Time.deltaTime);
            }
        }
    }
}