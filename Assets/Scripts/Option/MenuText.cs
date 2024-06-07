using System;
using TMPro;
using UnityEngine;

namespace Anthology
{
    [RequireComponent(typeof(TMP_Text))]
    public class MenuText : MonoBehaviour
    {
        private enum Field
        {
            Title,
            Blurb,
            Button
        }
        
        private Menu m_menu;

        private TMP_Text m_text;

        [SerializeField] private Field m_field;

        private void Awake()
        {
            m_menu = FindObjectOfType<Menu>();

            m_text = GetComponent<TMP_Text>();
            
            m_menu.OnOptionSelected.AddListener(OnOptionSelected);
        }

        private void OnOptionSelected(int _index)
        {
            var details = m_menu.Options[_index].Details;
            m_text.text = m_field switch
            {
                Field.Title => details.name,
                Field.Blurb => details.Blurb,
                Field.Button => details.ButtonVerb,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
