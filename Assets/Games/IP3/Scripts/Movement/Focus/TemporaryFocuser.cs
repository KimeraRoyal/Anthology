using IP3.Movement;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace IP2.Movement.Focus
{
    [RequireComponent(typeof(IMover))]
    public class TemporaryFocuser : MonoBehaviour, IFocuser
    {
        private IMover m_mover;
        
        private Vector3 m_position;
        private Vector3? m_focusedPosition;

        private bool m_dirty;

        public Vector3 Position
        {
            get => m_position;
            set
            {
                m_position = value;
                m_dirty = true;
            }
        }

        public Vector3? FocusedPosition
        {
            get => m_focusedPosition;
            set
            {
                m_focusedPosition = value;
                m_dirty = true;
            }
        }

        public bool Focused => m_focusedPosition != null;

        private void Awake()
        {
            m_mover = GetComponent<IMover>();
        }

        private void Update()
        {
            if(!m_dirty) { return; }

            var position = m_focusedPosition ?? m_position;
            m_mover.SetTargetPosition(position);
            
            m_dirty = false;
        }

        public bool GetFocused()
            => Focused;

        public void FocusOn(Vector3? _targetPosition)
            => FocusedPosition = _targetPosition;
    }
}
