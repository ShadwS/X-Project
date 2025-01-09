using Leopotam.Ecs;
using UnityEngine;

namespace Core.MouseLook
{
    public sealed class PlayerMouseLookSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerMouseLookComponent> _playerFilter = null;

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                ref var playerMouseLookComponent = ref _playerFilter.Get1(i);
                ref var cameraTransform = ref playerMouseLookComponent.Camera;
                ref var playerTransform = ref playerMouseLookComponent.Player;

                cameraTransform.Rotate(cameraTransform.right * Input.GetAxis("Mouse Y") * -100 * Time.deltaTime);
                playerTransform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 100 * Time.deltaTime);
            }
        }
    }
}