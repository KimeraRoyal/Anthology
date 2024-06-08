using UnityEngine;
using UnityEngine.Events;

namespace Anthology
{
    public class MenuOption : MonoBehaviour
    {
        private OptionDetails m_details;
        
        private float m_angle;
        private bool m_angleDirty;

        private bool m_selected;
        private bool m_firstSelected;

        public OptionDetails Details
        {
            get => m_details;
            set
            {
                if(m_details == value) { return; }
                
                m_details = value;
                OnDetailsChanged?.Invoke(m_details);
            }
        }

        public float Angle
        {
            get => m_angle;
            set
            {
                m_angle = value;
                m_angleDirty = true;
                
                OnAngleChanged?.Invoke(m_angle);
            }
        }

        public bool Selected
        {
            get => m_selected;
            set
            {
                if(m_selected == value) { return; }
                
                m_selected = value;
                
                if(m_selected) { OnSelected?.Invoke(m_firstSelected); }
                else { OnDeselected?.Invoke(); }

                m_firstSelected = false;
            }
        }

        public bool FirstSelected
        {
            get => m_firstSelected;
            set => m_firstSelected = value;
        }

        public UnityEvent<OptionDetails> OnDetailsChanged;

        public UnityEvent<float> OnAngleChanged;

        public UnityEvent<bool> OnSelected;
        public UnityEvent OnDeselected;

        private void Update()
        {
            if (m_angleDirty)
            {
                var angles = transform.localEulerAngles;
                angles.y = m_angle;
                transform.localEulerAngles = angles;

                m_angleDirty = false;
            }
        }

        public void Select()
            => Selected = true;

        public void Deselect()
            => Selected = false;
    }
}
