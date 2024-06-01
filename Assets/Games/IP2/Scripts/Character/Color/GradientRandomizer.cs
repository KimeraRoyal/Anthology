using UnityEngine;

namespace IP2.Character.Color
{
    [CreateAssetMenu(fileName = "Gradient Randomizer",  menuName = "Graphics/Gradient Randomizer")]
    public class GradientRandomizer : ColorRandomizer
    {
        [SerializeField] private Gradient m_gradient;

        public override UnityEngine.Color GenerateColor()
            => m_gradient.Evaluate(Random.Range(0.0f, 1.0f));
    }
}