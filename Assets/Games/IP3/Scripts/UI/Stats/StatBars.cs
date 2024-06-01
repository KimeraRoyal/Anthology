using System;
using UnityEngine;

namespace IP3
{
    public class StatBars : MonoBehaviour
    {
        private DollStats m_stats;

        [SerializeField] private StatBar m_statBarPrefab;

        private StatBar[] m_statBars;

        private void Awake()
        {
            m_stats = FindObjectOfType<DollStats>();
        }

        private void Start()
        {
            m_statBars = new StatBar[m_stats.Stats.Length];
            for (var i = 0; i < m_statBars.Length; i++)
            {
                m_statBars[i] = Instantiate(m_statBarPrefab, transform);
                m_statBars[i].Stat = m_stats.Stats[i];
            }
        }
    }
}
