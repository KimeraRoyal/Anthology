using System;
using IP2.Character.Selection;
using UnityEngine;
using CharacterInfo = IP2.Character.CharacterInfo;

namespace IP2.UI.Traits
{
    public class LineSelection : MonoBehaviour
    {
        private enum Category
        {
            Name,
            Role,
            Quote
        }
        
        private Selector m_selector;
        
        private TextLine m_textLine;

        [SerializeField] private Category m_category;
        
        [SerializeField] private bool m_keepCopying;

        private string m_line;

        private void Awake()
        {
            m_selector = FindObjectOfType<Selector>();
            
            m_textLine = GetComponent<TextLine>();
        }

        private void Start()
        {
            m_selector.OnCharacterSelected += OnCharacterSelected;
            ChangeLine(m_selector.SelectedCharacter);
        }

        private void OnCharacterSelected(CharacterInfo _character)
        {
            if(!m_keepCopying) { return; }

            ChangeLine(_character);
        }

        private void ChangeLine(CharacterInfo _character)
        {
            var text = m_line;
            if (_character)
            {
                text = m_category switch
                {
                    Category.Name => _character.Name.Text,
                    Category.Role => _character.Role.Text,
                    Category.Quote => _character.GetFormattedQuote(),
                    _ => throw new ArgumentOutOfRangeException()
                };
                m_line = text;
            }
            m_textLine.ChangeText(text);
        }
    }
}
