using UnityEngine;
using UnityEngine.Events;

public class Window : MonoBehaviour
{
    [SerializeField] private bool m_enabled;

    public bool Enabled
    {
        get => m_enabled;
        set
        {
            if(m_enabled == value) { return; }
            m_enabled = value;
            
            if(m_enabled) { OnEnabled?.Invoke(); }
            else { OnDisabled?.Invoke(); }
            OnEnabledChanged?.Invoke(m_enabled);
        }
    }

    public UnityEvent<bool> OnEnabledChanged;
    public UnityEvent OnEnabled;
    public UnityEvent OnDisabled;

    private void Start()
    {
        var wasEnabled = m_enabled;
        m_enabled = !wasEnabled;
        Enabled = wasEnabled;
    }

    public void Show()
        => Enabled = true;

    public void Hide()
        => Enabled = false;
}
