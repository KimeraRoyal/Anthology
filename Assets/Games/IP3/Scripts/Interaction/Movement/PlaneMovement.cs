using UnityEngine;

namespace IP3.Interaction.Movement
{
    public abstract class PlaneMovement : Movement
    {
        [SerializeField] private Vector3 m_horizontal = Vector3.right;
        [SerializeField] private Vector3 m_vertical = Vector3.up;

        private void Awake()
        {
            m_horizontal.Normalize();
            m_vertical.Normalize();
        }

        protected Vector3 TransformMovementPlane(Vector2 _movementPlane)
            => m_horizontal.normalized * _movementPlane.x + m_vertical.normalized * _movementPlane.y;
    }
}