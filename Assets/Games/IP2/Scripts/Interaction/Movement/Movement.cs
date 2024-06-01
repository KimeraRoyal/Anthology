using System;
using UnityEngine;

namespace IP2.Interaction.Movement
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] private Vector3 m_movementSpeed = Vector3.one;
        [SerializeField] private float m_speedFactor = 1.0f;
        
        public Action<Vector3> OnMove;

        protected virtual void Move(Vector3 _amount)
            => OnMove?.Invoke(new Vector3(_amount.x * m_movementSpeed.x, _amount.y * m_movementSpeed.y, _amount.z * m_movementSpeed.z) * m_speedFactor);
    }
}
