using UnityEngine;

namespace IP3
{
    [CreateAssetMenu(fileName = "New Stat Incrementer", menuName = "Stat Modifiers/Stat Incrementer")]
    public class StatIncrementer : StatModifier
    {
        [SerializeField] private float m_increment = 1.0f;

        public override void OnAdded(DollStat _stat, float _factor)
            => _stat.Value += m_increment * _factor;

        public override void OnRemoved(DollStat _stat, float _factor)
            => _stat.Value -= m_increment * _factor;
    }
}
