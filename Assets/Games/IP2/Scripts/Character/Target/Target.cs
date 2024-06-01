using System;
using IP2.Character;
using UnityEngine;

namespace IP2
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private TraitCategories m_traitCategories;
        [SerializeField] private TraitCategories m_impossibleTraitCategories;
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
        {
            var normalTraits = Array.Empty<Trait>();
            if (m_traitCount > 1) { normalTraits = m_traitCategories.GetTraits(m_traitCount - 1); }

            var traits = new Trait[m_traitCount];
            for (var i = 0; i < m_traitCount - 1; i++)
            {
                traits[i] = normalTraits[i];
            }
            traits[m_traitCount - 1] = m_impossibleTraitCategories.GetTrait();

            Traits = traits;
        }
    }
}
