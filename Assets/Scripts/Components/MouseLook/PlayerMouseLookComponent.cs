using UnityEngine;
using System;

namespace Core.MouseLook
{
    [Serializable]
    public struct PlayerMouseLookComponent
    {
        public Transform Camera;
        public Transform Player;
    }
}