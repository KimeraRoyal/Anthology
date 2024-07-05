using System;
using FMODUnity;
using UnityEngine;

namespace Anthology
{
    [RequireComponent(typeof(Menu))]
    public class MenuSounds : MonoBehaviour
    {
        private Menu m_menu;
        private MenuFunctions m_menuFunctions;
        
        [SerializeField] private EventReference m_menuMoveSound;
        [SerializeField] private EventReference m_menuMoveSoundShort;

        [SerializeField] private EventReference m_gamePlayedSound;
        [SerializeField] private EventReference m_poemPlayedSound;

        private int m_last = -1;

        private void Awake()
        {
            m_menu = GetComponent<Menu>();
            m_menuFunctions = GetComponent<MenuFunctions>();
            
            m_menu.OnOptionSelected.AddListener(OnOptionSelected);
            
            m_menuFunctions.OnGameLoaded.AddListener(OnGameLoaded);
            m_menuFunctions.OnPoemLoaded.AddListener(OnPoemLoaded);
        }

        private void OnGameLoaded()
            => RuntimeManager.PlayOneShot(m_gamePlayedSound);

        private void OnPoemLoaded()
            => RuntimeManager.PlayOneShot(m_poemPlayedSound);

        private void OnOptionSelected(int _index, bool _firstSelected)
        {
            if (_firstSelected)
            {
                m_last = _index;
                return;
            }

            var unwrappedLast = m_last;

            var halfCount = m_menu.Options.Count / 2;
            if (_index < halfCount && m_last > halfCount) { m_last -= m_menu.Options.Count; }
            if (_index > halfCount && m_last < halfCount) { m_last += m_menu.Options.Count; }
            
            var distance = Math.Min(Math.Abs(_index - m_last), Math.Abs(_index - unwrappedLast));

            var moveSound = distance > 1 ? m_menuMoveSound : m_menuMoveSoundShort;
            RuntimeManager.PlayOneShot(moveSound);
            m_last = _index;
        }
    }
}
