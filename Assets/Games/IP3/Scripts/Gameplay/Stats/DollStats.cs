using System.Collections.Generic;
using UnityEngine;

namespace IP3
{
    public class DollStats : MonoBehaviour
    {
        [SerializeField] private StatsData m_data;

        [SerializeField] private DollStat[] m_stats;
        private Dictionary<string, DollStat> m_statDictionary;

        public DollStat[] Stats => m_stats;
        public Dictionary<string, DollStat> StatDictionary => m_statDictionary;

        private void Awake()
        {
            m_stats = new DollStat[m_data.Stats.Length];
            m_statDictionary = new Dictionary<string, DollStat>();
            
            for (var i = 0; i < m_stats.Length; i++)
            {
                m_stats[i] = new DollStat(m_data.Stats[i]);
                m_statDictionary.Add(m_stats[i].Stat.Name, m_stats[i]);
            }
        }
    }
}
