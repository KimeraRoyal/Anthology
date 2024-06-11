using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Anthology
{
    public class Menu : MonoBehaviour
    {
        [Serializable]
        private class OptionDetailsEntry
        {
            [SerializeField] private OptionDetails m_optionDetails;

            public OptionDetails OptionDetails => m_optionDetails;

            public UnityEvent OnOptionClicked;

            public void Click()
                => OnOptionClicked?.Invoke();
        }

        private MenuState m_menuState;

        [SerializeField] private OptionDetailsEntry[] m_optionDetails;
        
        [SerializeField] private MenuOption m_optionPrefab;

        private MenuOption[] m_options;

        private int m_selectedIndex = -1;

        public IReadOnlyList<MenuOption> Options => m_options;

        public int SelectedOptionIndex => m_selectedIndex;
        public MenuOption SelectedOption => m_options[m_selectedIndex];

        public UnityEvent OnOptionsInitialized;
        
        public UnityEvent<int, bool> OnOptionSelected;

        private void Start()
        {
            m_menuState = FindObjectOfType<MenuState>();
            
            var optionCount = m_optionDetails.Length;
            
            m_options = new MenuOption[optionCount];
            var theta = 360.0f / optionCount;
            
            for (var i = 0; i < optionCount; i++)
            {
                
                m_options[i] = Instantiate(m_optionPrefab, transform);
                m_options[i].Details = m_optionDetails[i].OptionDetails;
                m_options[i].Angle = 360.0f - theta * i;

                var index = i;
                m_options[i].OnSelected.AddListener(firstSelected => SelectOption(index, firstSelected));
            }

            if (m_options.Length > 0)
            {
                m_options[m_menuState.SelectedEntry].FirstSelected = true;
                m_options[m_menuState.SelectedEntry].Selected = true;
            }
            
            OnOptionsInitialized?.Invoke();
        }

        private void SelectOption(int _index, bool _firstSelected)
        {
            if(m_selectedIndex == _index) { return; }

            if(m_selectedIndex >= 0) { m_options[m_selectedIndex].Selected = false; }
            m_selectedIndex = _index;

            m_menuState.SelectedEntry = m_selectedIndex;
            OnOptionSelected?.Invoke(m_selectedIndex, _firstSelected);
        }

        public void ClickSelectedOption()
        {
            if(m_selectedIndex < 0) { return; }
            
            m_options[m_selectedIndex].Click();
            m_optionDetails[m_selectedIndex].Click();
        }
    }
}
