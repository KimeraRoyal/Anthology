using UnityEngine;

namespace IP3.Gameplay.Clothes
{
    public class Clothing : MonoBehaviour
    {
        [SerializeField] private string m_attachmentPointName;

        public string AttachmentPointName => m_attachmentPointName;
    }
}
