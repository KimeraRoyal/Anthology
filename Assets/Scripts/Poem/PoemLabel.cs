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

    private TMP_Text m_text;

    [SerializeField] private Poem m_poem;
    [SerializeField] private LabelType m_type;

    private bool m_dirty;

    private void Awake()
    {
        m_text = GetComponent<TMP_Text>();
        
        m_dirty = true;
    }

    private void Start()
        => UpdateLabel();

    private void Update()
        => UpdateLabel();

    private void UpdateLabel()
    {
        if(!m_dirty) { return; }

        m_text.text = m_type switch
        {
            LabelType.Title => m_poem.name,
            LabelType.Author => m_poem.Author,
            LabelType.Body => m_poem.Body,
            _ => throw new ArgumentOutOfRangeException()
        };

        m_dirty = false;
    }
}
