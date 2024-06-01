using UnityEngine;

namespace IP2.Graphics.SpriteAnimation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteRendererAnimator : SpriteAnimator
    {
        private SpriteRenderer m_spriteRenderer;
        
        protected override void Awake()
        {
            base.Awake();
            
            m_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected override void ChangeSprite(Sprite _sprite)
            => m_spriteRenderer.sprite = _sprite;
    }
}
