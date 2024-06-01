using System;
using IP3.Gameplay.Clothes;
using UnityEngine;

namespace UI.Icons
{
    public class AttachmentPointIcon : MonoBehaviour
    {
        private AttachmentPointIconImage[] m_images;

        public Action<bool> OnAttachmentStateChanged;

        private void Awake()
        {
            m_images = GetComponentsInChildren<AttachmentPointIconImage>();
        }

        public void LinkToPoint(AttachmentPoint _attachmentPoint)
        {
            ChangeIconGraphic(_attachmentPoint.GetComponent<IconGraphic>());
        
            _attachmentPoint.OnClothingAttached += OnClothingAttached;
            _attachmentPoint.OnClothingDetached += OnClothingDetached;
        }

        private void OnClothingAttached(ClothingAttacher _clothing)
            => OnAttachmentStateChanged?.Invoke(_clothing);

        private void OnClothingDetached(ClothingAttacher _clothing)
            => OnAttachmentStateChanged?.Invoke(false);

        private void ChangeIconGraphic(IconGraphic _graphic)
        {
            if(!_graphic) { return; }

            foreach (var image in m_images)
            {
                image.Sprite = _graphic.Sprite;
            }
        }
    }
}
