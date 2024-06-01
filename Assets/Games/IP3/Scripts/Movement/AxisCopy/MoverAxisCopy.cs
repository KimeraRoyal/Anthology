using IP3.Movement;
using UnityEngine;

namespace IP2.Movement.AxisCopy
{
    [RequireComponent(typeof(Mover))]
    public class MoverAxisCopy : MonoBehaviour
    {
        private Mover m_mover;

        [SerializeField] private Vector3 m_offset;
        [SerializeField] private float m_factor = 1.0f;

        private void Awake()
        {
            m_mover = GetComponent<Mover>();
        }

        private void Start()
        {
            m_mover.OnTruePositionChanging += OnPositionChanging;
        }

        private Vector3 OnPositionChanging(Vector3 _position)
            => new(_position.x + m_offset.x, _position.y + m_offset.y, _position.z + _position.y * m_factor + m_offset.z);
    }
}
