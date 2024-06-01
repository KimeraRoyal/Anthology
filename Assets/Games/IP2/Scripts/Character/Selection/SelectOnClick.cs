using UnityEngine;

namespace IP2.Character.Selection
{
    [RequireComponent(typeof(Clicker))]
    public class SelectOnClick : MonoBehaviour
    {
        private Selector m_selector;
        
        private Clicker m_clicker;

        private void Awake()
        {
            m_selector = FindObjectOfType<Selector>();
            
            m_clicker = GetComponent<Clicker>();
        }

        private void Start()
        {
            m_clicker.OnClick += OnClick;
        }

        private void OnClick(Clickable _clickable)
        {
            CharacterInfo selectedCharacter = null;
            if (_clickable)
            {
                selectedCharacter = _clickable.GetComponent<CharacterInfo>();
            }
            m_selector.SelectedCharacter = selectedCharacter;
        }
    }
}
