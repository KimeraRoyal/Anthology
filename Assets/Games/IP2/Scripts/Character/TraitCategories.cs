using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace IP2.Character
{
    [CreateAssetMenu(fileName = "Traits", menuName = "Gameplay/Traits", order = 0)]
    public class TraitCategories : ScriptableObject
    {
        [SerializeField] private TraitCategory[] m_categories;

        public Trait GetTrait()
        {
            var categoryIndex = Random.Range(0, m_categories.Length);
                
            var descriptorIndex = Random.Range(0, m_categories[categoryIndex].Descriptions.Length);
            var traitElementIndices = new int[m_categories[categoryIndex].TraitElements.Length];
            for (var j = 0; j < traitElementIndices.Length; j++)
            {
                traitElementIndices[j] = Random.Range(0, m_categories[categoryIndex].TraitElements[j].Traits.Length);
            }
                
            return new Trait(this, categoryIndex, descriptorIndex, traitElementIndices);
        }

        public Trait[] GetTraits(int _count)
        {
            var categories = new List<int>(m_categories.Length);
            for (var i = 0; i < m_categories.Length; i++)
            {
                categories.Add(i);
            }
            
            var traits = new Trait[_count];
            for (var i = 0; i < _count; i++)
            {
                var category = Random.Range(0, categories.Count);
                
                var categoryIndex = categories[category];
                categories.RemoveAt(category);
                
                var descriptorIndex = Random.Range(0, m_categories[categoryIndex].Descriptions.Length);
                var traitElementIndices = new int[m_categories[categoryIndex].TraitElements.Length];
                for (var j = 0; j < traitElementIndices.Length; j++)
                {
                    traitElementIndices[j] = Random.Range(0, m_categories[categoryIndex].TraitElements[j].Traits.Length);
                }
                
                traits[i] = new Trait(this, categoryIndex, descriptorIndex, traitElementIndices);
            }

            return traits;
        }

        public string GetText(Trait _trait)
        {
            var category = m_categories[_trait.CategoryIndex];

            var description = category.Descriptions[_trait.DescriptorIndex];
            var args = new object[category.TraitElements.Length];
            for (var i = 0; i < args.Length; i++)
            {
                args[i] = category.TraitElements[i].Traits[_trait.TraitElementIndices[i]];
            }

            return string.Format(description, args);
        }
    }
}
