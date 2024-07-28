using System;
using UnityEngine;

public class Hoverable : MonoBehaviour
{
    public Action OnHover;
    public Action OnUnhover;

    private bool m_hovered;
    
    public void Hover()
    {
        if(m_hovered) { return; }
        OnHover?.Invoke();
        m_hovered = true;
    }

    public void Unhover()
    {
        if(!m_hovered) { return; }
        OnUnhover?.Invoke();
        m_hovered = false;
    }
}
