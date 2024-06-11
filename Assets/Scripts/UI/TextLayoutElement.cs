using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class TextLayoutElement : MonoBehaviour
{
    private LayoutElement m_element;
    private TMP_Text m_text;

    [SerializeField] private float m_height;

    private string m_lastText;

    private void Awake()
    {
        m_element = GetComponent<LayoutElement>();
        m_text = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        UpdateElementHeight();
    }

    private void Update()
    {
        if(m_text.text == m_lastText) { return; }

        UpdateElementHeight();
        
        m_lastText = m_text.text;
    }

    private void UpdateElementHeight()
        => m_element.minHeight = m_text.text == "" ? 0 : m_height;
}
