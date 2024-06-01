using System;
using IP2.Character.Selection;
using IP2.Movement;
using UnityEngine;
using CharacterInfo = IP2.Character.CharacterInfo;

namespace IP2
{
    public class SpawnOnSelection : MonoBehaviour
    {
        private Selector m_selector;
        
        [SerializeField] private CopyMover m_prefab;

        [SerializeField] private bool m_spawnIfDead;

        private CharacterInfo m_lastTarget;
        private CopyMover m_lastSpawned;

        private void Awake()
        {
            m_selector = FindObjectOfType<Selector>();
            
            m_selector.OnCharacterSelected += OnCharacterSelected;
        }

        private void OnCharacterSelected(CharacterInfo _character)
        {
            DisableCopying(_character);
            
            if(!_character || (!_character.Alive && !m_spawnIfDead)) { return; }
            
            var spawned = Instantiate(m_prefab, transform);
            spawned.gameObject.SetActive(true);

            m_lastTarget = _character;
            m_lastSpawned = spawned;
        }

        private void DisableCopying(CharacterInfo _newCharacter)
        {
            if(!m_lastTarget || m_lastTarget == _newCharacter) { return; }

            m_lastSpawned.KeepCopying = false;

            m_lastTarget = null;
            m_lastSpawned = null;
        }
    }
}
