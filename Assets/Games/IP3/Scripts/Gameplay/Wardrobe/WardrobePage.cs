using IP3.Gameplay.Clothes;
using UnityEngine;

namespace IP3.Gameplay.Wardrobe
{
    public class WardrobePage : MonoBehaviour
    {
        private Clothing[] m_clothing;

        private void Awake()
        {
            m_clothing = GetComponentsInChildren<Clothing>();
        }
    }
}
