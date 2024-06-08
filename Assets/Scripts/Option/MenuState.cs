using UnityEngine;

namespace Anthology
{
    public class MenuState : MonoBehaviour
    {
        private int m_selectedEntry;

        public int SelectedEntry
        {
            get => m_selectedEntry;
            set => m_selectedEntry = value;
        }
        
        private void Awake()
        {
            var menuState = FindObjectOfType<MenuState>();
            if (menuState != this) { Destroy(gameObject); }
            DontDestroyOnLoad(gameObject);
        }
    }
}
