using System;

namespace Core.Movement
{
    [Serializable]
    public struct PlayerSpeedComponent
    {
        public float Speed => _speed;

        [UnityEngine.SerializeField] private float _speed;
    }
}