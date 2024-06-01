using System;
using UnityEngine;

namespace IP2.Character
{
    [Serializable]
    public class TraitElement
    {
        [SerializeField] private string[] m_traits;

        public string[] Traits => m_traits;
    }
    
    [CreateAssetMenu(fileName = "Trait Category", menuName = "Gameplay/Trait Category", order = 1)]
    public class TraitCategory : ScriptableObject
    {
        [SerializeField] private string[] m_descriptions;
        [SerializeField] private TraitElement[] m_traitElements;
        
        public string[] Descriptions => m_descriptions;
        public TraitElement[] TraitElements => m_traitElements;
    }
}
