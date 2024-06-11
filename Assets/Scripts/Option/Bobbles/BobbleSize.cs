using Anthology;
using DG.Tweening;
using UnityEngine;

public class BobbleSize : MonoBehaviour
{
    private BobbleButton m_bobble;

    private RectTransform m_rectTransform;

    [SerializeField] private Vector4 m_deselectedSize = Vector4.one;
    [SerializeField] private Vector4 m_selectedSize = Vector4.one;
    [SerializeField] private float m_resizeDuration = 1.0f;
    [SerializeField] private Ease m_resizeEase = Ease.Linear;

    private Sequence m_resizeSequence;

    private void Awake()
    {
        m_bobble = GetComponentInParent<BobbleButton>();

        m_rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        m_bobble.Option.OnSelected.AddListener(OnSelected);
        m_bobble.Option.OnDeselected.AddListener(OnDeselected);

        ChangeSize(m_bobble.Option.Selected ? m_selectedSize : m_deselectedSize, true);
    }

    private void OnSelected(bool _firstSelected)
        => ChangeSize(m_selectedSize, _firstSelected);

    private void OnDeselected()
        => ChangeSize(m_deselectedSize, false);

    private void ChangeSize(Vector4 _size, bool _firstSelected)
    {
        var minOffset = new Vector2(_size.x, _size.y);
        var maxOffset = new Vector2(_size.z, _size.w);

        if (_firstSelected)
        {
            m_rectTransform.offsetMin = minOffset;
            m_rectTransform.offsetMax = maxOffset;
            return;
        }
        
        if(m_resizeSequence is { active: true }) { m_resizeSequence.Kill(); }

        m_resizeSequence = DOTween.Sequence();
        m_resizeSequence.Insert(0, DOTween.To(() => m_rectTransform.offsetMin, value => m_rectTransform.offsetMin = value, minOffset, m_resizeDuration).SetEase(m_resizeEase));
        m_resizeSequence.Insert(0, DOTween.To(() => m_rectTransform.offsetMax, value => m_rectTransform.offsetMax = value, maxOffset, m_resizeDuration).SetEase(m_resizeEase));
    }
}
