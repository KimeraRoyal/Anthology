using System;
using IP2.Character.Color;
using UnityEngine;

namespace IP2.Character
{
    public class CharacterInfo : MonoBehaviour
    {
        [SerializeField] private TraitCategories m_nameCategories;
        [SerializeField] private TraitCategories m_roleCategories;
        [SerializeField] private TraitCategories m_quoteCategories;
        
        [SerializeField] private TraitCategories m_traitCategories;
        [SerializeField] private int m_traitCount = 3;

        [SerializeField] private TypingStyles m_typingStyles;

        [SerializeField] private ColorRandomizer m_colorRandomizer;

        private Trait m_name;
        private Trait m_role;
        private Trait m_quote;
        
        private Trait[] m_traits;

        private TypingStyle m_typingStyle;

        private UnityEngine.Color m_color;

        private bool m_isAlive;

        public Trait Name
        {
            get => m_name;
            private set
            {
                m_name = value;
                OnNameSet?.Invoke(m_name);
            }
        }

        public Trait Role
        {
            get => m_role;
            private set
            {
                m_role = value;
                OnRoleSet?.Invoke(m_role);
            }
        }

        public Trait Quote
        {
            get => m_quote;
            private set
            {
                m_quote = value;
                OnQuoteSet?.Invoke(m_quote);
            }
        }
        
        public Trait[] Traits
        {
            get => m_traits;
            private set
            {
                m_traits = value;
                OnTraitsSet?.Invoke(m_traits);
            }
        }

        public TypingStyle TypingStyle
        {
            get => m_typingStyle;
            private set
            {
                m_typingStyle = value;
                OnTypingStyleSet?.Invoke(m_typingStyle);
            }
        }

        public UnityEngine.Color Color
        {
            get => m_color;
            private set
            {
                m_color = value;
                OnColorSet?.Invoke(m_color);
            }
        }

        public bool Alive
        {
            get => m_isAlive;
            set
            {
                if(m_isAlive == value) { return; }
                
                m_isAlive = value;
                OnLifeChanged?.Invoke(m_isAlive);
            }
        }

        public Action<Trait> OnNameSet;
        public Action<Trait> OnRoleSet;
        public Action<Trait> OnQuoteSet;
        
        public Action<Trait[]> OnTraitsSet;
        
        public Action<TypingStyle> OnTypingStyleSet;

        public Action<UnityEngine.Color> OnColorSet;

        public Action OnPersonified;

        public Action<bool> OnLifeChanged;

        private void Start()
        {
            Personify();
        }

        public void Personify()
        {
            Name = m_nameCategories.GetTrait();
            Role = m_roleCategories.GetTrait();
            Quote = m_quoteCategories.GetTrait();
            
            Traits = m_traitCategories.GetTraits(m_traitCount);

            TypingStyle = m_typingStyles.GetRandomStyle();

            Color = m_colorRandomizer.GenerateColor();

            Alive = true;
            
            OnPersonified?.Invoke();
        }

        public string GetFormattedQuote()
            => m_typingStyle.FormatText(m_quote.Text);
    }
}
