using IP2.Graphics.Colorable;
using UnityEngine;
using CharacterInfo = IP2.Character.CharacterInfo;

namespace IP2
{
    [RequireComponent(typeof(CharacterInfo))]
    public class CharacterColorizer : MonoBehaviour
    {
        private IColorable[] m_colorable;
        
        private void Awake()
        {
            m_colorable = GetComponentsInChildren<IColorable>(true);
            
            var character = GetComponent<CharacterInfo>();
            character.OnColorSet += OnColorSet;
        }

        private void OnColorSet(Color _color)
        {
            foreach (var colorable in m_colorable)
            {
                colorable.SetColor(_color);
            }
        }
    }
}
