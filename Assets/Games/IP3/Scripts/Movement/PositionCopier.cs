using UnityEngine;

namespace IP3.Movement
{
    public class PositionCopier : MonoBehaviour
    {
        [SerializeField] private Transform m_target;

        [SerializeField] private Vector3 m_factor = Vector3.one;
        [SerializeField] private Vector3 m_offset;

        public Transform Target
        {
            get => m_target;
            set => m_target = value;
        }
        
        private void Update()
        {
            if(!m_target) { return; }

            var position = m_target.position;
            transform.position = new Vector3(position.x * m_factor.x, position.y * m_factor.y, position.z * m_factor.z) + m_offset;
        }
    }
}
