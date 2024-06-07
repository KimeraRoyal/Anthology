using UnityEngine;

namespace Anthology
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class MenuOptionIcon : MonoBehaviour
    {
        private MenuOption m_option;

        private SpriteRenderer m_spriteRenderer;

        private void Awake()
        {
            m_option = GetComponentInParent<MenuOption>();

            m_spriteRenderer = GetComponent<SpriteRenderer>();
            
            m_option.OnDetailsChanged.AddListener(OnDetailsChanged);
        }

        private void OnDetailsChanged(OptionDetails _details)
            => m_spriteRenderer.sprite = _details.Icon;
    }
}
