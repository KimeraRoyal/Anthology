using System;
using IP3.Movement;
using UnityEngine;
using UnityEngine.Events;

namespace Anthology
{
    public class MenuOption : MonoBehaviour
    {
        [SerializeField] private Mover m_mover;
        
        [SerializeField] private float m_unselectedDistance, m_selectedDistance;
        
        [SerializeField] private float m_angle;

        private bool m_selected;
        private bool m_selectedDirty;

        public bool Selected
        {
            get => m_selected;
            set
            {
                if(m_selected == value) { return; }
                
                m_selected = value;
                m_selectedDirty = true;
                
                OnSelected?.Invoke();
            }
        }

        public float Angle
        {
            get => m_angle;
            set => m_angle = value;
        }

        public UnityEvent OnSelected;

        private void Awake()
        {
            if(!m_mover) { m_mover = GetComponent<Mover>(); }
        }

        private void Update()
        {
            var angles = transform.localEulerAngles;
            angles.y = m_angle;
            transform.localEulerAngles = angles;

            if (m_selectedDirty)
            {
                m_mover.TargetPosition = Vector3.forward * (m_selected ? m_selectedDistance : m_unselectedDistance);
                m_selectedDirty = false;
            }
        }

        public void Select()
            => Selected = true;

        public void Deselect()
            => Selected = false;
    }
}
