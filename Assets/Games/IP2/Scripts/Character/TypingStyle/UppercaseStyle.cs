using UnityEngine;

namespace IP2
{
    [CreateAssetMenu(fileName = "Uppercase", menuName = "Typing Styles/Uppercase", order = 2)]
    public class UppercaseStyle : TypingStyle
    {
        public override string FormatText(string _in)
            => base.FormatText(_in).ToUpper();
    }
}
