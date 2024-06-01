using UnityEngine;

namespace IP2.Character.Color
{
    public abstract class ColorRandomizer : ScriptableObject
    {
        public abstract UnityEngine.Color GenerateColor();
    }
}
