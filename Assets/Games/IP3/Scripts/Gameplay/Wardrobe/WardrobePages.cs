using System;
using UnityEngine;

namespace IP3.Gameplay.Wardrobe
{
    public class WardrobePages : MonoBehaviour
    {
        private Wardrobe m_wardrobe;

        [SerializeField] private WardrobePage[] m_pagePrefabs;

        private WardrobePage[] m_pages;
        private int m_activePageIndex;

        public WardrobePage[] Pages => m_pages;

        public int ActivePageIndex
        {
            get => m_activePageIndex;
            set
            {
                if(m_activePageIndex == value || m_pages == null) { return; }

                value = Mathf.Clamp(value, 0, m_pages.Length);
                
                ShowActivePage(value, m_activePageIndex);
                m_activePageIndex = value;
                
                OnPageChanged?.Invoke(m_activePageIndex);
            }
        }

        public Action<int> OnPageChanged;

        private void Awake()
        {
            m_wardrobe = FindObjectOfType<Wardrobe>();

            m_pages = new WardrobePage[m_pagePrefabs.Length];
            for (var i = 0; i < m_pages.Length; i++)
            {
                m_pages[i] = Instantiate(m_pagePrefabs[i], transform);
                m_pages[i].gameObject.SetActive(i == m_activePageIndex);
            }
        }

        private void ShowActivePage(int _activePageIndex, int _last)
        {
            m_pages[_last].gameObject.SetActive(false);
            m_pages[_activePageIndex].gameObject.SetActive(true);
        }
    }
}
