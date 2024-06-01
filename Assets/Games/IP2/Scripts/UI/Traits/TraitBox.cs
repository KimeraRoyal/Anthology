using System;
using UnityEngine;

namespace IP2
{
    public class TraitBox : MonoBehaviour
    {
        private TextLine[] m_traitLines;

        private void Awake()
        {
            m_traitLines = GetComponentsInChildren<TextLine>();
        }

        public void ChangeLines(string[] _lines)
        {
            for (var i = 0; i < m_traitLines.Length; i++)
            {
                var line = "";
                if (i < _lines.Length)
                {
                    line = _lines[i]; 
                }
                m_traitLines[i].ChangeText(line);
            }
        }
    }
}
