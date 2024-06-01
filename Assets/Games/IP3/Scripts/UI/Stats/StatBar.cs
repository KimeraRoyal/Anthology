using System;
using UnityEngine;

namespace IP3
{
    public class StatBar : MonoBehaviour
    {
        private DollStat m_stat;

        public DollStat Stat
        {
            get => m_stat;
            set
            {
                if(m_stat == value) { return; }

                m_stat = value;
                OnStatChanged?.Invoke(m_stat);
            }
        }

        public Action<DollStat> OnStatChanged;
    }
}
