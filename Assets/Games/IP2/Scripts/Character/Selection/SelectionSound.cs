using System;
using FMODUnity;
using IP2.Character.Selection;
using UnityEngine;
using CharacterInfo = IP2.Character.CharacterInfo;

namespace IP2
{
    public class SelectionSound : MonoBehaviour
    {
        private Selector m_selector;

        [SerializeField] private EventReference m_selectSound;

        private void Awake()
        {
            m_selector = FindObjectOfType<Selector>();
            
            m_selector.OnCharacterSelected += OnCharacterSelected;
        }

        private void OnCharacterSelected(CharacterInfo _character)
        {
            if(!_character) { return; }
            RuntimeManager.PlayOneShot(m_selectSound);
        }
    }
}
