using System;
using UnityEngine;

namespace IP3
{
    public class ClothingStatModifiers : MonoBehaviour
    {
        [Serializable]
        public class ClothingStatModifier
        {
            [SerializeField] private string m_statName;
            [SerializeField] private StatModifier m_modifier;

            [SerializeField] private float m_factor = 1.0f;
            
            [SerializeField] private DollStat m_targetStat;

            public string StatName => m_statName;
            public StatModifier Modifier => m_modifier;

            public float Factor => m_factor;

            public DollStat TargetStat
            {
                get => m_targetStat;
                set => m_targetStat = value;
            }
        }
        
        [SerializeField] private ClothingStatModifier[] m_modifiers;
        [SerializeField] private StatModifier m_defaultModifier;

        private void Start()
        {
            var dollStats = FindObjectOfType<DollStats>();
            foreach (var modifier in m_modifiers)
            {
                modifier.TargetStat = dollStats.StatDictionary[modifier.StatName];
            }
        }

        public void OnAdded()
        {
            foreach (var modifier in m_modifiers)
            {
                var statModifier = modifier.Modifier ? modifier.Modifier : m_defaultModifier;
                statModifier.OnAdded(modifier.TargetStat, modifier.Factor);
            }
        }

        public void OnRemoved()
        {
            foreach (var modifier in m_modifiers)
            {
                var statModifier = modifier.Modifier ? modifier.Modifier : m_defaultModifier;
                statModifier.OnRemoved(modifier.TargetStat, modifier.Factor);
            }
        }
    }
}
