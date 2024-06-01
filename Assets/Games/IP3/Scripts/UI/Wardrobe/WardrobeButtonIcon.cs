using IP3.Gameplay.Wardrobe;
using UI.Icons;
using UnityEngine;
using UnityEngine.UI;

namespace IP3.UI.Wardrobe
{
    [RequireComponent(typeof(Image))]
    public class WardrobeButtonIcon : MonoBehaviour
    {
        private WardrobeButton m_button;
        
        private Image m_image;

        private void Awake()
        {
            m_button = GetComponentInParent<WardrobeButton>();
            
            m_image = GetComponent<Image>();
            
            m_button.OnTrackedPageChanged += OnTrackedPageChanged;
        }

        private void OnTrackedPageChanged(WardrobePage _page)
        {
            var icon = _page.GetComponent<IconGraphic>();
            if(!icon) { return; }

            m_image.sprite = icon.Sprite;
        }
    }
}