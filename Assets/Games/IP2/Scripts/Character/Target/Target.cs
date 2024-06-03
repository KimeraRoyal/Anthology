using System;
using IP2.Character;
using UnityEngine;

namespace IP2
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private TraitCategories m_traitCategories;
        [SerializeField] private int m_traitCount = 3;
        
        private Trait[] m_traits;
        
        public Trait[] Traits
        {
            get => m_traits;
            private set
            {
                m_traits = value;
                OnTraitsSet?.Invoke(m_traits);
            }
        }
        
        public Action<Trait[]> OnTraitsSet;

        private void Start()
        {
            Personify();
        }

        public void Personify()
            => Traits = m_traitCategories.GetTraits(m_traitCount);
    }
}
