using UnityEngine;

namespace IP3
{
    [CreateAssetMenu(fileName = "Stats", menuName = "Stats")]
    public class StatsData : ScriptableObject
    {
        [SerializeField] private Stat[] m_stats;

        public Stat[] Stats => m_stats;
    }
}
