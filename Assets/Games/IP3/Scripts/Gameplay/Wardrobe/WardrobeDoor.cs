using DG.Tweening;
using UnityEngine;

namespace IP3.Gameplay.Wardrobe
{
    public class WardrobeDoor : MonoBehaviour
    {
        private Wardrobe m_wardrobe;

        [SerializeField] private Vector3 m_openRotation, m_closeRotation;
        [SerializeField] private float m_openRotationDuration = 1.0f, m_closeRotationDuration = 1.0f;
        [SerializeField] private Ease m_openRotationEase = Ease.Linear, m_closeRotationEase = Ease.Linear;

        [SerializeField] private Vector3 m_openScale = Vector3.one, m_closeScale = Vector3.one;
        [SerializeField] private float m_openScaleDelay, m_closeScaleDelay;
        [SerializeField] private float m_openScaleDuration = 1.0f, m_closeScaleDuration = 1.0f;
        [SerializeField] private Ease m_openScaleEase = Ease.Linear, m_closeScaleEase = Ease.Linear;

        private Sequence m_openCloseSequence;
    
        private void Awake()
        {
            m_wardrobe = GetComponentInParent<Wardrobe>();
        }

        private void Start()
        {
            m_wardrobe.OnOpened += OnOpened;
            m_wardrobe.OnClosed += OnClosed;

            transform.localEulerAngles = m_wardrobe.Open ? m_openRotation : m_closeRotation;
            transform.localScale = m_wardrobe.Open ? m_openScale : m_closeScale;
        }

        private void OnOpened()
            => OpenCloseSequence(true);

        private void OnClosed()
            => OpenCloseSequence(false);

        private void OpenCloseSequence(bool _open)
        {
            var rotation = _open ? m_openRotation : m_closeRotation;
            var rotationDuration = _open ? m_openRotationDuration : m_closeRotationDuration;
            var rotationEase = _open ? m_openRotationEase : m_closeRotationEase;
        
            var scale = _open ? m_openScale : m_closeScale;
            var scaleDelay = _open ? m_openScaleDelay : m_closeScaleDelay;
            var scaleDuration = _open ? m_openScaleDuration : m_closeScaleDuration;
            var scaleEase = _open ? m_openScaleEase : m_closeScaleEase;
        
            if(m_openCloseSequence is { active: true }) { m_openCloseSequence.Kill(); }

            m_openCloseSequence = DOTween.Sequence();
            m_openCloseSequence.Append(transform.DOLocalRotateQuaternion(Quaternion.Euler(rotation), rotationDuration).SetEase(rotationEase));
            m_openCloseSequence.Insert(scaleDelay, transform.DOScale(scale, scaleDuration).SetEase(scaleEase));
        }
    }
}
