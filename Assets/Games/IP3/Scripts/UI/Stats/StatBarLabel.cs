using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace IP3
{
    [RequireComponent(typeof(TMP_Text))]
    public class StatBarLabel : MonoBehaviour
    {
        private StatBar m_statBar;

        private TMP_Text m_text;

        private void Awake()
        {
            m_statBar = GetComponentInParent<StatBar>();

            m_text = GetComponent<TMP_Text>();
            
            m_statBar.OnStatChanged += OnStatChanged;
        }

        private void OnStatChanged(DollStat _stat)
            => m_text.text = _stat.Stat.Name;
    }
}
