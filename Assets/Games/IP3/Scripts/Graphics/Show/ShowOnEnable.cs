using UnityEngine;

namespace IP3.Graphics.Show
{
    [RequireComponent(typeof(IShowable))]
    public class ShowOnEnable : MonoBehaviour
    {
        private IShowable m_showable;

        private void Awake()
        {
            m_showable = GetComponent<IShowable>();
        }

        private void OnEnable()
        {
            m_showable.Show();
        }

        private void OnDisable()
        {
            m_showable.Hide();
        }
    }
}
