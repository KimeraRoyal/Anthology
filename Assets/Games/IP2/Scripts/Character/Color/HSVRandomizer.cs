using UnityEngine;

namespace IP2.Character.Color
{
    [CreateAssetMenu(fileName = "HSV Randomizer",  menuName = "Graphics/HSV Randomizer")]
    public class HSVRandomizer : ColorRandomizer
    {
        [SerializeField] private Vector2 m_hueRange = Vector2.up;
        [SerializeField] private Vector2 m_saturationRange = Vector2.up;
        [SerializeField] private Vector2 m_brightnessRange = Vector2.up;

        public override UnityEngine.Color GenerateColor()
        {
            var h = Random.Range(m_hueRange.x, m_hueRange.y);
            var s = Random.Range(m_saturationRange.x, m_saturationRange.y);
            var v = Random.Range(m_brightnessRange.x, m_brightnessRange.y);

            return UnityEngine.Color.HSVToRGB(h, s, v);
        }
    }
}