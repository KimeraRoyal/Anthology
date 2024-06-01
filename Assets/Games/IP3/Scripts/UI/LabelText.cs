using UnityEngine;

namespace IP3
{
    public class LabelText : MonoBehaviour
    {
        [SerializeField] private string m_text;

        public string Text => m_text;
    }
}
