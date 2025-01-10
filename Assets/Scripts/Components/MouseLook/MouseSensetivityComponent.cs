using UnityEngine;
using System;

namespace Core.MouseLook
{
    [Serializable]
    public struct MouseSensetivityComponent
    {
        public int Sensetivity => _sensetivity;

        [Range(50,150)]
        [SerializeField] private int _sensetivity;
    }
}