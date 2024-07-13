using UnityEngine.UI;

namespace Anthology
{
    public class ClickGroupElement : SoundGroupElement
    {
        private void Awake()
        {
            GetComponentInChildren<Button>().onClick.AddListener(InvokeElement);
        }
    }
}
