using UnityEngine;

namespace Anthology
{
    [CreateAssetMenu(fileName = "New Menu Option", menuName = "Title Screen/Menu Option")]
    public class OptionDetails : ScriptableObject
    {
        [TextArea(1, 3)] [SerializeField] private string m_blurb = "A short descriptive blurb.";
        [SerializeField] private string m_buttonVerb = "Play";
        
        [SerializeField] private Sprite m_icon;

        public string Blurb => m_blurb;
        public string ButtonVerb => m_buttonVerb;
        
        public Sprite Icon => m_icon;
    }
}
