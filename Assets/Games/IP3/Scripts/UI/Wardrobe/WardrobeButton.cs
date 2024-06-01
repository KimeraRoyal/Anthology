using System;
using IP3.Gameplay.Wardrobe;
using UnityEngine;
using UnityEngine.UI;

public class WardrobeButton : MonoBehaviour
{
    private WardrobePages m_pages;

    private Button m_button;
    
    private int m_trackedIndex = -1;

    public Action<WardrobePage> OnTrackedPageChanged;

    public int TrackedIndex
    {
        get => m_trackedIndex;
        set
        {
            if(m_trackedIndex == value) { return; }

            m_trackedIndex = value;
            OnTrackedPageChanged?.Invoke(m_pages.Pages[m_trackedIndex]);
        }
    }

    private void Awake()
    {
        m_pages = FindObjectOfType<WardrobePages>();

        m_button = GetComponentInChildren<Button>();
    }

    private void Start()
    {
        m_pages.OnPageChanged += OnPageChanged;
        OnPageChanged(m_pages.ActivePageIndex);
        
        m_button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        m_pages.ActivePageIndex = m_trackedIndex;
    }

    private void OnPageChanged(int _pageIndex)
    {
        m_button.interactable = m_trackedIndex != _pageIndex;
    }
}
