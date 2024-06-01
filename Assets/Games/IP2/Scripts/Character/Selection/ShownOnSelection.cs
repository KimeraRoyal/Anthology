using System;
using IP2.Character.Selection;
using UnityEngine;
using CharacterInfo = IP2.Character.CharacterInfo;

namespace IP2
{
    [RequireComponent(typeof(IShowable))]
    public class ShownOnSelection : MonoBehaviour
    {
        private Selector m_selector;
        
        private IShowable m_panel;

        private CharacterInfo m_character;

        [SerializeField] private bool m_closeWhenDead;

        private void Awake()
        {
            m_selector = FindObjectOfType<Selector>();

            m_panel = GetComponent<IShowable>();
            
            m_selector.OnCharacterSelected += OnCharacterSelected;
        }

        private void Start()
        {
            OnCharacterSelected(m_selector.SelectedCharacter);
        }

        private void OnDestroy()
        {
            if(!m_character) { return; }
            
            m_character.OnLifeChanged -= OnLifeChanged;
        }

        private void OnCharacterSelected(CharacterInfo _character)
        {
            if (!_character || (m_character && _character != m_character))
            {
                m_panel.Hide();
                return;
            }
            
            m_panel.Show();
            
            m_character = _character;
            m_character.OnLifeChanged += OnLifeChanged;
        }

        private void OnLifeChanged(bool _alive)
        {
            if(!m_closeWhenDead) { return; }
            
            m_panel.Hide();
        }
    }
}
