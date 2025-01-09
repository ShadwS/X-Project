using UnityEngine;
using System;

namespace Core.Movement
{
    [Serializable]
    public struct CharacterControllerComponent
    {
        public CharacterController CharacterController => _characterController;

        [SerializeField] private CharacterController _characterController;
    }
}