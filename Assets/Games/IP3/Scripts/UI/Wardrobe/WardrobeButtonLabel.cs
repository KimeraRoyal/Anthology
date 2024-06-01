using IP3.Gameplay.Wardrobe;
using TMPro;
using UnityEngine;

namespace IP3.UI.Wardrobe
{
    [RequireComponent(typeof(TMP_Text))]
    public class WardrobeButtonLabel : MonoBehaviour
    {
        private WardrobeButton m_button;
        
        private TMP_Text m_text;

        private void Awake()
        {
            m_button = GetComponentInParent<WardrobeButton>();
            
            m_text = GetComponent<TMP_Text>();
            
            m_button.OnTrackedPageChanged += OnTrackedPageChanged;
        }

        private void OnTrackedPageChanged(WardrobePage _page)
        {
            var label = _page.GetComponent<LabelText>();
            if(!label) { return; }

            m_text.text = label.Text;
        }
    }
}