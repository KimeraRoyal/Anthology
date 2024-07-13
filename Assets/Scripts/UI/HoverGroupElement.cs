using UnityEngine.EventSystems;

namespace Anthology
{
    public class HoverGroupElement : SoundGroupElement, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            InvokeElement();
        }
    }
}
