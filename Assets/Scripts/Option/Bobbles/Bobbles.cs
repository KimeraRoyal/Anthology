using UnityEngine;

namespace Anthology
{
    public class Bobbles : MonoBehaviour
    {
        private Menu m_menu;

        [SerializeField] private BobbleButton m_bobblePrefab;

        private void Awake()
        {
            m_menu = FindObjectOfType<Menu>();
            
            m_menu.OnOptionsInitialized.AddListener(OnOptionsInitialized);
        }

        private void OnOptionsInitialized()
        {
            var count = m_menu.Options.Count;
            for (var i = 0; i < count; i++)
            {
                var bobble = Instantiate(m_bobblePrefab, transform);
                bobble.Option = m_menu.Options[i];
            }
        }
    }
}
