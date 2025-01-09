using UnityEngine;

namespace Core.Movement
{
    public struct MyInput : IInput
    {
        public Vector3 GetDirection()
        {
            Vector3 direction = new(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
            direction = direction.normalized;

            return direction;
        }
    }
}