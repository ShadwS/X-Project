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

                if (xRotate < 180)//����
                {
                    Debug.Log(xRotate);
                }
                if (xRotate > 180)//�����
                {
                    Debug.Log(xRotate - 360);
                    xRotate = xRotate - 360;
                }
                xRotate = Mathf.Clamp(xRotate, -clampX, clampX);
                if (xRotate < 0)
                {
                    xRotate = 360 + xRotate;
                }

                //if (xRotate >= 0 && xRotate < 180)
                //{
                //    xRotate = Mathf.Clamp(xRotate, 0, clampX);
                //}
                //else
                //{
                //    xRotate = Mathf.Clamp(xRotate, 360 - clampX, 359.99f);
                //    if (xRotate >= 359.5f)
                //    {
                //        xRotate = 0;
                //    }
                //}

                cameraTransform.rotation = Quaternion.Euler(xRotate, playerTransform.rotation.eulerAngles.y, 0);
            }
        }
    }
}