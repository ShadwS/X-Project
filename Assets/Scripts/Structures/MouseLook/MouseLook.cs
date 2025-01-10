using UnityEngine;

namespace Core.MouseLook
{
    public struct MouseLook : IMouseLook
    {
        public float GetX() => Input.GetAxis("Mouse X");

        public float GetY() => Input.GetAxis("Mouse Y");
    }
}