using UnityEngine;
using UnityEngine.Events;

public class PoemWindow : MonoBehaviour
{
    private Poem m_poem;
    
    private Transform m_child;

    [SerializeField] private bool m_enabled;

    public Poem Poem
    {
        get => m_poem;
        set
        {
            if(m_poem == value) { return; }

            m_poem = value;
            
            OnPoemChanged?.Invoke(m_poem);
        }
    }

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

    public UnityEvent<Poem> OnPoemChanged;

    public UnityEvent<bool> OnEnabledChanged;
    public UnityEvent OnEnabled;
    public UnityEvent OnDisabled;

    private void Awake()
    {
        m_child = transform.GetChild(0);
        OnEnabledChanged.AddListener(EnableChild);
    }

    private void Start()
    {
        var wasEnabled = m_enabled;
        m_enabled = !wasEnabled;
        Enabled = wasEnabled;
    }

    private void EnableChild(bool _enabled)
        => m_child.gameObject.SetActive(m_enabled);

    public void Show()
        => Enabled = true;

    public void Hide()
        => Enabled = false;
}
