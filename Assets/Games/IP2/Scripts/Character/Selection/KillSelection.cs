using IP2.Character.Selection;
using UnityEngine;

namespace IP2
{
    public class KillSelection : MonoBehaviour
    {
        private Selector m_selector;

        private void Awake()
        {
            m_selector = FindObjectOfType<Selector>();
        }

        public void Kill()
        {
            m_selector.SelectedCharacter.Alive = false;
        }
    }
}
