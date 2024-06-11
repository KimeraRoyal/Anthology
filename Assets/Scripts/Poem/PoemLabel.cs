using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class PoemLabel : MonoBehaviour
{
    private enum LabelType
    {
        Title,
        Author,
        Body
    }

    private PoemSwitcher m_switcher;

    private TMP_Text m_text;

    [SerializeField] private LabelType m_type;

    private void Awake()
    {
        m_switcher = GetComponentInParent<PoemSwitcher>();
        
        m_text = GetComponent<TMP_Text>();
        
        m_switcher.OnPoemChanged.AddListener(UpdateLabel);
    }

    private void Start()
        => UpdateLabel(m_switcher.Poem);

    private void UpdateLabel(Poem _poem)
    {
        if(!_poem) { return; }
        
        m_text.text = m_type switch
        {
            LabelType.Title => _poem.name,
            LabelType.Author => _poem.Author,
            LabelType.Body => _poem.Body,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
