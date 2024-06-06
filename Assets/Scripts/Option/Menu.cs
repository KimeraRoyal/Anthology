using UnityEngine;
using UnityEngine.Events;

namespace Anthology
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private int m_numOptions = 1;
        
        [SerializeField] private MenuOption m_optionPrefab;

        private MenuOption[] m_options;

        private int m_selectedIndex = -1;
        
        public UnityEvent<int> OnOptionSelected;

        private void Start()
        {
            m_options = new MenuOption[m_numOptions];
            var theta = 360.0f / m_numOptions;
            
            for (var i = 0; i < m_numOptions; i++)
            {
                m_options[i] = Instantiate(m_optionPrefab, transform);
                m_options[i].Angle = theta * i;

                var index = i;
                m_options[i].OnSelected.AddListener(() => SelectOption(index));
            }

            if(m_options.Length < 1) { return; }
            m_options[0].Selected = true;
        }

        private void SelectOption(int _index)
        {
            if(m_selectedIndex == _index) { return; }

            if(m_selectedIndex >= 0) { m_options[m_selectedIndex].Selected = false; }
            
            m_selectedIndex = _index;
            OnOptionSelected?.Invoke(m_selectedIndex);
        }
    }
}
