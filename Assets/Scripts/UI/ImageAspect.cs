using System;
using UnityEngine;
using UnityEngine.UI;

namespace Anthology
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(RectTransform), typeof(Image))]
    public class ImageAspect : MonoBehaviour
    {
        private enum Aspect
        {
            WidthControlsHeight,
            HeightControlsWidth
        }
        
        private RectTransform m_rectTransform;

        private Image m_image;
        private LayoutElement m_element;

        [SerializeField] private Aspect m_aspect;

        private Vector2 m_previousSpriteSize;
        private Vector2 m_previousSize;

        private void Awake()
        {
            m_rectTransform = GetComponent<RectTransform>();
            
            m_image = GetComponent<Image>();
            m_element = GetComponent<LayoutElement>();
        }

        private void Start()
        {
            UpdateSize(true);
        }

        private void Update()
        {
            UpdateSize(false);
        }

        private void UpdateSize(bool _force)
        {
            if (!m_image.sprite)
            {
                m_rectTransform.sizeDelta = Vector2.zero;
                m_element.preferredWidth = 0;
                m_element.preferredHeight = 0;
                return;
            }
            
            var spriteRect = m_image.sprite.rect;
            var spriteSize = new Vector2(spriteRect.width, spriteRect.height);
            var sizeDelta = m_rectTransform.sizeDelta;

            if (!_force &&
                ((sizeDelta - m_previousSize).magnitude < 0.001f || (spriteSize - m_previousSpriteSize).magnitude < 0.001f))
            {
                return;
            }

            UpdateAspectRatio(spriteSize, sizeDelta);
            
            m_previousSpriteSize = spriteSize;
            m_previousSize = sizeDelta;
        }

        private void UpdateAspectRatio(Vector2 spriteSize, Vector2 sizeDelta)
        {
            switch (m_aspect)
            {
                case Aspect.WidthControlsHeight:
                    sizeDelta.y = spriteSize.y * (sizeDelta.x / spriteSize.x);
                    m_element.preferredHeight = sizeDelta.y;
                    break;
                case Aspect.HeightControlsWidth:
                    sizeDelta.x = spriteSize.x * (sizeDelta.y / spriteSize.y);
                    m_element.preferredWidth = sizeDelta.x;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            m_rectTransform.sizeDelta = sizeDelta;
        }
    }
}
