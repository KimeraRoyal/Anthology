using System;
using UnityEngine;

namespace IP3.Gameplay.Wardrobe
{
    public class Wardrobe : MonoBehaviour
    {
        private WardrobePages m_pages;
    
        private bool m_open;

        public Action OnOpened;
        public Action OnClosed;
    
        public bool Open
        {
            get => m_open;
            set
            {
                if(m_open == value) { return; }

                m_open = value;
                if(m_open) { OnOpened?.Invoke(); }
                else { OnClosed?.Invoke(); }
            }
        }

        private void Awake()
        {
            m_pages = FindObjectOfType<WardrobePages>();
        }

        private void Start()
        {
            Open = true;
        }
    }
}
