using UnityEngine;
using UnityEngine.UI;

namespace IP2.Graphics.SpriteAnimation
{
    [RequireComponent(typeof(Image))]
    public class ImageAnimator : SpriteAnimator
    {
        private Image m_image;

        protected override void Awake()
        {
            base.Awake();
            
            m_image = GetComponent<Image>();
        }

        protected override void ChangeSprite(Sprite _sprite)
            => m_image.sprite = _sprite;
    }
}
