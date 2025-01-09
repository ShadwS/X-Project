using System;
using UnityEngine;

namespace Core.Movement
{
    [Serializable]
    public struct PlayerJumpComponent
    {
        public float JumpForce => _jumpForce;
        public float GravityForce => _gravityForce;
        public float BaseGravity => _baseGravity;

        public float VelocityY;

        [SerializeField] private float _jumpForce;
        [SerializeField] private float _gravityForce;
        [SerializeField] private float _baseGravity;
    }
}