using UnityEngine;

namespace IP2
{
    [CreateAssetMenu(fileName = "Normal", menuName = "Typing Styles/Normal", order = 1)]
    public class TypingStyle : ScriptableObject
    {
        public virtual string FormatText(string _in)
            => _in;
    }
}
