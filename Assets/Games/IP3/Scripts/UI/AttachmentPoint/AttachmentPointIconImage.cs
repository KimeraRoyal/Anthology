using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Icons
{
    [RequireComponent(typeof(Image))]
    public class AttachmentPointIconImage : MonoBehaviour
    {
        private AttachmentPointIcon m_icon;
    
        private Image m_image;

        [SerializeField] private bool m_changeableGraphic;

        [SerializeField] private Color m_detachedColor = Color.white;
        [SerializeField] private Color m_attachedColor = Color.white;
        [SerializeField] private float m_colorChangeDuration = 1.0f;

        private Tween m_colorChangeTween;
    
        public Sprite Sprite
        {
            get => m_image.sprite;
            set
            {
                if(!m_changeableGraphic) { return; }
                m_image.sprite = value;
            }
        }

        private void Awake()
        {
            m_icon = GetComponentInParent<AttachmentPointIcon>();
        
            m_image = GetComponent<Image>();
        }

        private void Start()
        {
            m_icon.OnAttachmentStateChanged += OnAttachmentStateChanged;
        }

        private void OnAttachmentStateChanged(bool _attached)
        {
            if(m_colorChangeTween is { active: true }) { m_colorChangeTween.Kill(); }

            var color = _attached ? m_attachedColor : m_detachedColor;
            m_colorChangeTween = DOTween.To(() => m_image.color, _value => m_image.color = _value, color, m_colorChangeDuration);
        }
    }
}
