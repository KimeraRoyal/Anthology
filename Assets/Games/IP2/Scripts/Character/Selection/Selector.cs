using System;
using UnityEngine;

namespace IP2.Character.Selection
{
    public class Selector : MonoBehaviour
    {
        private CharacterInfo m_selectedCharacter;

        public CharacterInfo SelectedCharacter
        {
            get => m_selectedCharacter;
            set
            {
                if(m_selectedCharacter == value) { return; }
                
                m_selectedCharacter = value;
                OnCharacterSelected?.Invoke(m_selectedCharacter);
            }
        }

        public Action<CharacterInfo> OnCharacterSelected;
    }
}
