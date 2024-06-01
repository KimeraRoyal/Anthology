using System;
using UnityEngine;

namespace IP3
{
    [Serializable]
    public class DollStat
    {
        [SerializeField] private Stat m_stat;

        [SerializeField] private float m_value;

        public Stat Stat => m_stat;

        public float Value
        {
            get => m_value;
            set
            {
                if(Mathf.Abs(m_value - value) < 0.001f) { return; }
                
                m_value = value;
                OnValueChanged?.Invoke(m_value);
            }
        }

        public DollStat(Stat _stat)
        {
            m_stat = _stat;
            m_value = m_stat.StartingValue;
        }

        public Action<float> OnValueChanged;
    }
}