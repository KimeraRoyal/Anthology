using IP3.Gameplay.Wardrobe;
using UnityEngine;

namespace IP3
{
    public class WardrobeButtons : MonoBehaviour
    {
        private WardrobePages m_pages;

        [SerializeField] private WardrobeButton m_buttonPrefab;

        private WardrobeButton[] m_buttons;
        
        private void Awake()
        {
            m_pages = FindObjectOfType<WardrobePages>();
        }

        private void Start()
        {
            m_buttons = new WardrobeButton[m_pages.Pages.Length];
            for (var i = 0; i < m_buttons.Length; i++)
            {
                m_buttons[i] = Instantiate(m_buttonPrefab, transform);
                m_buttons[i].TrackedIndex = i;
            }
        }
    }
}
