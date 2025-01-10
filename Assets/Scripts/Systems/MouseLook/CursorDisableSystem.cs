using Leopotam.Ecs;
using UnityEngine;

namespace Core.MouseLook
{
    public sealed class CursorDisableSystem : IEcsInitSystem
    {
        public void Init()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
    }
}