using IP3.Movement;
using UnityEngine;

namespace Anthology
{
    [RequireComponent(typeof(Mover))]
    public class MenuOptionMover : MonoBehaviour
    {
        private MenuOption m_option;
        
        private Mover m_mover;
        
        [SerializeField] private float m_deselectedDistance, m_selectedDistance;

        private void Awake()
        {
            m_option = GetComponentInParent<MenuOption>();
            
            m_mover = GetComponent<Mover>();
            
            m_option.OnSelected.AddListener(OnSelected);
            m_option.OnDeselected.AddListener(OnDeselected);
        }

        private void OnSelected(bool _firstSelected)
            => ChangePosition(m_selectedDistance, _firstSelected);

        private void OnDeselected()
            => ChangePosition(m_deselectedDistance, false);

        private void ChangePosition(float _distance, bool _firstSelected)
        {
            var targetPosition = Vector3.forward * _distance;
            
            if (_firstSelected) { m_mover.CurrentPosition = targetPosition; }
            m_mover.TargetPosition = targetPosition;
        }
    }
}