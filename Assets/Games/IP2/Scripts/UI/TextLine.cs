using TMPro;
using UnityEngine;

namespace IP2
{
    public class TextLine : MonoBehaviour
    {
        private TMP_Text m_text;

        private void Awake()
        {
            m_text = GetComponentInChildren<TMP_Text>();
        }

        public void ChangeText(string _text)
            => m_text.text = _text;
    }
}
