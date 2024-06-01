using System;
using UnityEngine;

namespace IP2.Character
{
    [Serializable]
    public class Trait
    {
        [SerializeField] private string m_text;
        
        [SerializeField] private int m_categoryIndex;
        [SerializeField] private int m_descriptorIndex;
        [SerializeField] private int[] m_traitElementIndices;

        public string Text => m_text;

        public int CategoryIndex => m_categoryIndex;
        public int DescriptorIndex => m_descriptorIndex;
        public int[] TraitElementIndices => m_traitElementIndices;

        public Trait(TraitCategories _categories, int _categoryIndex, int _descriptorIndex, int[] _traitElementIndices)
        {
            m_categoryIndex = _categoryIndex;
            m_descriptorIndex = _descriptorIndex;
            m_traitElementIndices = _traitElementIndices;
            
            m_text = _categories.GetText(this);
        }
    }
}
