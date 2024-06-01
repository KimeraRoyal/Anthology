using IP2.Movement;
using UnityEngine;

namespace IP2
{
    public class RelayMover : MonoBehaviour, IMover
    {
        [SerializeField] private Mover m_mover;

        public Vector3 GetTargetPosition()
            => m_mover.GetTargetPosition();

        public void SetTargetPosition(Vector3 _targetPosition)
            => m_mover.SetTargetPosition(_targetPosition);
    }
}
