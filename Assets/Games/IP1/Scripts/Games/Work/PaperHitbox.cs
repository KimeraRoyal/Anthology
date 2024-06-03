using UnityEngine;

namespace IP1
{
    public class PaperHitbox : MonoBehaviour
    {
        private Paper m_paper;

        public Paper Paper => m_paper;

        private void Awake()
        {
            m_paper = GetComponentInParent<Paper>();
        }
    }
}
