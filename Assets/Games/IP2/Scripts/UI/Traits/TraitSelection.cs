using System;
using System.Collections.Generic;
using IP2.Character;
using IP2.Character.Selection;
using UnityEngine;
using CharacterInfo = IP2.Character.CharacterInfo;

namespace IP2
{
    [RequireComponent(typeof(TraitBox))]
    public class TraitSelection : MonoBehaviour
    {
        private enum Source
        {
            SelectedCharacter,
            TargetCharacter
        }
        
        private Selector m_selector;
        private Target m_target;
        
        private TraitBox m_traitBox;

        [SerializeField] private Source m_source;
        [SerializeField] private bool m_keepCopying;

        private string[] m_traits;

        private void Awake()
        {
            m_selector = FindObjectOfType<Selector>();
            m_target = FindObjectOfType<Target>();
            
            m_traitBox = GetComponent<TraitBox>();
            
            m_traits = Array.Empty<string>();
        }

        private void Start()
        {
            m_selector.OnCharacterSelected += OnCharacterSelected;
            m_target.OnTraitsSet += OnTargetUpdated;

            switch (m_source)
            {
                case Source.SelectedCharacter:
                {
                    var traits = Array.Empty<Trait>();
                    if (m_selector.SelectedCharacter) { traits = m_selector.SelectedCharacter.Traits; }
                    ChangeLines(traits);
                    
                    break;
                }
                case Source.TargetCharacter:
                {
                    ChangeLines(m_target.Traits);
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void OnCharacterSelected(CharacterInfo _character)
        {
            if(!m_keepCopying || m_source != Source.SelectedCharacter) { return; }
            
            var traits = Array.Empty<Trait>();
            if (_character) { traits = _character.Traits; }
            ChangeLines(traits);
        }

        private void OnTargetUpdated(IReadOnlyList<Trait> _traits)
        {
            if(!m_keepCopying || m_source != Source.TargetCharacter) { return; }
            
            ChangeLines(_traits);
        }

        private void ChangeLines(IReadOnlyList<Trait> _traits)
        {
            if(m_traits is { Length: 0 } && _traits is { Count: > 0 } ) { m_traits = new string[_traits.Count]; }
                
            for (var i = 0; i < m_traits.Length; i++)
            {
                if (_traits.Count > i)
                {
                    m_traits[i] = _traits[i].Text;
                }
            }
            m_traitBox.ChangeLines(m_traits);
        }
    }
}
