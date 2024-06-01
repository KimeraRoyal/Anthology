using IP2.Movement;
using UnityEngine;

namespace IP2
{
    public class SmoothMover : Mover
    {
        [SerializeField] private float m_movementSmoothTime = 1.0f;

        private Vector3 m_velocity;

        private void Update()
        {
            if(Mathf.Abs((CurrentPosition - OffsetPosition).magnitude) < 0.001f) { return; }

            CurrentPosition = Vector3.SmoothDamp(CurrentPosition, OffsetPosition, ref m_velocity, m_movementSmoothTime);
        }
    }
}
