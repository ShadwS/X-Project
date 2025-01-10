using UnityEngine;
using System;

namespace Core.MouseLook
{
    [Serializable]
    public struct PlayerCameraClampRotatation
    {
        public int MaxAngkeX => _maxAngkeX;

        [SerializeField] private int _maxAngkeX;
    }
}