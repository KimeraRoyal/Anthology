using UnityEngine;

namespace IP2.Graphics.SpriteAnimation
{
    [CreateAssetMenu(fileName = "Sprite Animation Set", menuName = "Graphics/Sprite Animation Set")]
    public class IndexedSpriteAnimationSet : SpriteAnimationSet
    {
        [SerializeField] private SpriteAnimation[] m_animations;

        [SerializeField] private int m_firstIndex;

        public SpriteAnimation[] Animations => m_animations;

        public override SpriteAnimation GetAnimation(int _index)
            => m_animations[_index];

        public override int GetAnimationCount()
            => m_animations.Length;

        public override int GetFirstAnimationIndex()
            => m_firstIndex < 0 ? Random.Range(0, m_animations.Length) : m_firstIndex;
    }
}
