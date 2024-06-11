using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Anthology
{
    [RequireComponent(typeof(Button))]
    public class BobbleButton : MonoBehaviour
    {
        private MenuOption m_option;

        private Button m_button;
        
        public UnityEvent OnPressed;

        public MenuOption Option
        {
            get => m_option;
            set => m_option = value;
        }

        private void Awake()
        {
            m_button = GetComponent<Button>();
            m_button.onClick.AddListener(OnButtonClick);
        }

        private void Start()
        {
            m_option.OnSelected.AddListener(OnSelected);
            m_option.OnDeselected.AddListener(OnDeselected);

            m_button.interactable = !m_option.Selected;
        }

        private void OnButtonClick()
        {
            m_option.Select();
            OnPressed?.Invoke();
        }

        private void OnSelected(bool _firstSelected)
        {
            m_button.interactable = false;
        }

        private void OnDeselected()
        {
            m_button.interactable = true;
        }
    }
}
