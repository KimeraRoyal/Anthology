using UnityEngine;
using UnityEngine.UI;

namespace Anthology
{
    public class MenuArrows : MonoBehaviour
    {
        private Menu m_menu;
        
        private Button[] m_arrows;

        private void Awake()
        {
            m_menu = FindObjectOfType<Menu>();
            
            m_arrows = GetComponentsInChildren<Button>();
            
            m_arrows[0].onClick.AddListener(() => ShiftMenu(-1));
            m_arrows[1].onClick.AddListener(() => ShiftMenu(1));
        }

        private void ShiftMenu(int _factor)
        {
            var index = m_menu.SelectedOptionIndex + _factor;
            if (index < 0) { index += m_menu.Options.Count; }
            if (index >= m_menu.Options.Count) { index -= m_menu.Options.Count; }
            
            m_menu.Options[index].Select();
        }
    }
}
