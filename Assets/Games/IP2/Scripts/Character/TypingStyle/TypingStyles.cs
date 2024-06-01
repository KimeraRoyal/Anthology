using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IP2
{
    [Serializable]
    public class TypingStyleChance
    {
        [SerializeField] private TypingStyle m_style;
        [SerializeField] private int m_chance = 1;

        [SerializeField] private int m_totalChance;

        public TypingStyle Style => m_style;
        public int Chance => m_chance;

        public int TotalChance
        {
            get => m_totalChance;
            set => m_totalChance = value;
        }
    }
    
    [CreateAssetMenu(fileName = "Typing Styles", menuName = "Typing Styles/Typing Styles", order = 0)]
    public class TypingStyles : ScriptableObject
    {
        [SerializeField] private TypingStyleChance[] m_styles;

        [SerializeField] private int m_totalChance;

        private void OnValidate()
        {
            m_totalChance = 0;
            foreach (var style in m_styles)
            {
                m_totalChance += style.Chance;
                style.TotalChance = m_totalChance;
            }
        }

        public TypingStyle GetStyle(int _index)
            => m_styles[_index].Style;

        public TypingStyle GetRandomStyle()
            => (from style in m_styles where Random.Range(0, m_totalChance) < style.TotalChance select style.Style).FirstOrDefault();

        public int GetRandomStyleIndex()
        {
            var chance = Random.Range(0, m_totalChance);
            for (var i = 0; i < m_styles.Length; i++)
            {
                if (chance < m_styles[i].TotalChance) { return i; }
            }
            return 0;
        }
    }
}