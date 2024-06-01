using UnityEngine;

namespace IP2
{
    [CreateAssetMenu(fileName = "Lowercase", menuName = "Typing Styles/Lowercase", order = 2)]
    public class LowercaseStyle : TypingStyle
    {
        public override string FormatText(string _in)
            => base.FormatText(_in).ToLower();
    }
}
