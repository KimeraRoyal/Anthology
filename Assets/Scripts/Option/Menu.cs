using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Anthology
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private OptionDetails[] m_optionDetails;
        
        [SerializeField] private MenuOption m_optionPrefab;

        private MenuOption[] m_options;

        private int m_selectedIndex = -1;

        public IReadOnlyList<MenuOption> Options => m_options;
        
        public UnityEvent<int, bool> OnOptionSelected;

        private void Start()
        {
            var optionCount = m_optionDetails.Length;
            
            m_options = new MenuOption[optionCount];
            var theta = 360.0f / optionCount;
            
            for (var i = 0; i < optionCount; i++)
            {
                m_options[i] = Instantiate(m_optionPrefab, transform);
                m_options[i].Details = m_optionDetails[i];
                m_options[i].Angle = 360.0f - theta * i;

                var index = i;
                m_options[i].OnSelected.AddListener(firstSelected => SelectOption(index, firstSelected));
            }

            if(m_options.Length < 1) { return; }

            m_options[0].FirstSelected = true;
            m_options[0].Selected = true;
        }

        private void SelectOption(int _index, bool _firstSelected)
        {
            if(m_selectedIndex == _index) { return; }

            if(m_selectedIndex >= 0) { m_options[m_selectedIndex].Selected = false; }
            
            m_selectedIndex = _index;
            OnOptionSelected?.Invoke(m_selectedIndex, _firstSelected);
        }
    }
}
