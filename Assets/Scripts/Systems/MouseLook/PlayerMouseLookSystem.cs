using Leopotam.Ecs;
using UnityEngine;

namespace Core.MouseLook
{
    public sealed class PlayerMouseLookSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<PlayerMouseLookComponent, MouseSensetivityComponent,
            PlayerCameraClampRotatation> _playerFilter = null;

        private MouseLook _mouse;
        public void Init() => _mouse = new();

        public void Run()
        {
            foreach (var i in _playerFilter)
            {
                ref var playerMouseLookComponent = ref _playerFilter.Get1(i);
                ref var mouseSensetivitycomponent = ref _playerFilter.Get2(i);
                ref var cameraClampRotationComponent = ref _playerFilter.Get3(i);

                ref var cameraTransform = ref playerMouseLookComponent.Camera;
                ref var playerTransform = ref playerMouseLookComponent.Player;
                var sensetivity = mouseSensetivitycomponent.Sensetivity;
                var clampX = cameraClampRotationComponent.MaxAngkeX;

                playerTransform.Rotate(Vector3.up * _mouse.GetX() * sensetivity * Time.deltaTime);

                var xRotate = cameraTransform.rotation.eulerAngles.x;

                xRotate -= _mouse.GetY() * sensetivity * Time.deltaTime;
                
                if (xRotate > 180)
                {
                    xRotate = xRotate - 360;
                }
                xRotate = Mathf.Clamp(xRotate, -clampX, clampX);
                if (xRotate < 0)
                {
                    xRotate = 360 + xRotate;
                }

                cameraTransform.rotation = Quaternion.Euler(xRotate, playerTransform.rotation.eulerAngles.y, 0);
            }
        }
    }
}