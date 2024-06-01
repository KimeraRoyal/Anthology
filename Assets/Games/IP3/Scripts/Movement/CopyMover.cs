using UnityEngine;

namespace IP3.Movement
{
    public class CopyMover : MonoBehaviour
    {
        private Mover m_mover;
        
        [SerializeField] private Mover m_target;

        [SerializeField] private bool m_copyTarget, m_copyCurrent;
        [SerializeField] private bool m_keepCopying;

        private void Awake()
        {
            m_mover = GetComponent<Mover>();
        }

        private void Start()
        {
            if (m_copyTarget)
            {
                m_target.OnTargetPositionChanged += UpdateTargetPosition;
                m_mover.TargetPosition = m_target.TargetPosition;
            }

            if (m_copyCurrent)
            {
                m_target.OnCurrentPositionChanged += UpdateCurrentPosition;
                m_mover.CurrentPosition = m_target.CurrentPosition;
            }
        }

        private void UpdateTargetPosition(Vector3 _position)
        {
            if(!m_keepCopying) { return; }
            m_mover.TargetPosition = _position;
        }

        private void UpdateCurrentPosition(Vector3 _position)
        {
            if(!m_keepCopying) { return; }
            m_mover.CurrentPosition = _position;
        }
    }
}
