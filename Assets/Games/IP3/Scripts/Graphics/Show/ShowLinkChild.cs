using UnityEngine;

namespace IP3.Graphics.Show
{
    [RequireComponent(typeof(IShowable))]
    public class ShowLinkChild : MonoBehaviour
    {
        private IShowable m_showable;

        public IShowable Showable => m_showable;

        private void Awake()
        {
            m_showable = GetComponent<IShowable>();
        }
    }
}
