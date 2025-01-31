using UnityEngine;

namespace Core.Movement
{
    public struct Movable : IInput
    {
        public Vector3 GetDirection(float y)
        {
            Vector3 direction = new(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
            direction = direction.normalized;
            direction.y = y;

            return direction;
        }
    }
}