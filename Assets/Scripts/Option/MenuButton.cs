using UnityEngine;
using UnityEngine.UI;

namespace Anthology
{
    [RequireComponent(typeof(Button))]
    public class MenuButton : MonoBehaviour
    {
        private Menu m_menu;

        private Button m_button;

        private void Awake()
        {
            m_menu = FindObjectOfType<Menu>();

            m_button = GetComponent<Button>();
            
            m_button.onClick.AddListener(OnClick);
        }

        private void OnClick()
            => m_menu.ClickSelectedOption();
    }
}
