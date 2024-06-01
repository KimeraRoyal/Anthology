using System;
using UnityEngine;

namespace IP3.Graphics.Show
{
    public class Showable : MonoBehaviour, IShowable
    {
        [SerializeField] private bool m_shown = true;

        public bool Shown
        {
            get => m_shown;
            set
            {
                if(m_shown == value) { return; }

                m_shown = value;

                if (m_shown)
                {
                    Show();
                    OnShow?.Invoke();
                }
                else
                {
                    Hide();
                    OnHide?.Invoke();
                }
            }
        }

        public Action OnShow;
        public Action OnHide;

        public void Show()
            => Shown = true;

        public void Hide()
            => Shown = false;
    }
}
