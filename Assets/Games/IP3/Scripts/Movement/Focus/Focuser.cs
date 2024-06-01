using IP3.Movement;
using UnityEngine;

namespace IP2.Movement.Focus
{
    public class Focuser : MonoBehaviour, IFocuser
    {
        private IMover m_mover;

        [SerializeField] private float m_factor = 1.0f;   

        private bool m_focused;

        public bool Focused => m_focused;
        
        private void Awake()
        {
            m_mover = GetComponent<IMover>();
        }

        public bool GetFocused()
            => Focused;

        public void FocusOn(Vector3? _targetPosition)
        {
            m_focused = _targetPosition != null;
            if(_targetPosition == null) { return; }

            m_mover.SetTargetPosition(_targetPosition.Value * m_factor);
        }
    }
}