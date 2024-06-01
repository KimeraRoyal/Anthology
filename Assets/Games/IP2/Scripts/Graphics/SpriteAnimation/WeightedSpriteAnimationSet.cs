using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IP2.Graphics.SpriteAnimation
{
    [Serializable]
    public class SpriteAnimationChance
    {
        [SerializeField] private SpriteAnimation m_animation;
        [SerializeField] private int m_chance = 1;

        [SerializeField] private int m_totalChance;

        public SpriteAnimation Animation => m_animation;
        public int Chance => m_chance;

        public int TotalChance
        {
            get => m_totalChance;
            set => m_totalChance = value;
        }
    }
    
    [CreateAssetMenu(fileName = "Weighted Sprite Animation Set", menuName = "Graphics/Weighted Sprite Animation Set")]
    public class WeightedSpriteAnimationSet : SpriteAnimationSet
    {
        [SerializeField] private SpriteAnimationChance[] m_animations;

        [SerializeField] private int m_totalChance;

        private void OnValidate()
        {
            m_totalChance = 0;
            foreach (var animation in m_animations)
            {
                m_totalChance += animation.Chance;
                animation.TotalChance = m_totalChance;
            }
        }

        public override SpriteAnimation GetAnimation(int _index)
            => m_animations[_index].Animation;

        public override int GetAnimationCount()
            => m_animations.Length;

        public override int GetFirstAnimationIndex()
        {
            var chance = Random.Range(0, m_totalChance);
            for (var i = 0; i < m_animations.Length; i++)
            {
                if (chance < m_animations[i].TotalChance) { return i; }
            }
            return 0;
        }
    }
}