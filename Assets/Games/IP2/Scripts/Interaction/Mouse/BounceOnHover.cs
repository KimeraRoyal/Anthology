using DG.Tweening;
using IP2.Character.Selection;
using UnityEngine;

using CharacterInfo = IP2.Character.CharacterInfo;

public class BounceOnHover : MonoBehaviour
{
    private Selector m_selector;
    
    private CharacterInfo m_characterInfo;
    private Hoverable m_hoverable;
    
    [SerializeField] private Vector3 m_amount = Vector3.one;
    [SerializeField] private float m_duration = 1.0f;
    [SerializeField] private int m_vibrato = 10;
    [SerializeField] private float m_elasticity = 1.0f;

    private Vector3 m_startingScale;

    private bool m_selected;
    
    private Tween m_bounceTween;

    private void Awake()
    {
        m_selector = FindObjectOfType<Selector>();
        
        m_characterInfo = GetComponent<CharacterInfo>();
        m_hoverable = GetComponent<Hoverable>();
        
        m_startingScale = transform.localScale;
    }

    private void Start()
    {
        m_hoverable.OnHover += OnHover;
        m_selector.OnCharacterSelected += OnCharacterSelected;
    }

    private void OnCharacterSelected(CharacterInfo _character)
    {
        m_selected = _character == m_characterInfo;
    }

    private void OnHover()
    {
        if(m_selected) { return; }
        
        if (m_bounceTween is { active: true })
        {
            m_bounceTween.Kill();
            transform.localScale = m_startingScale;
        }

        m_bounceTween = transform.DOPunchScale(m_amount, m_duration, m_vibrato, m_elasticity);
    }
}
