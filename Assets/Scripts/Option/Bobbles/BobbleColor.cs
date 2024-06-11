using Anthology;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class BobbleColor : MonoBehaviour
{
    private BobbleButton m_bobble;

    private Image m_image;

    [SerializeField] private Color m_deselectedColor = Color.white;
    [SerializeField] private Color m_selectedColor = Color.white;
    [SerializeField] private float m_fadeDuration = 1.0f;
    [SerializeField] private Ease m_fadeEase = Ease.Linear;

    private Tween m_tween;

    private void Awake()
    {
        m_bobble = GetComponentInParent<BobbleButton>();

        m_image = GetComponent<Image>();
    }

    private void Start()
    {
        m_bobble.Option.OnSelected.AddListener(OnSelected);
        m_bobble.Option.OnDeselected.AddListener(OnDeselected);

        ChangeColor(m_bobble.Option.Selected ? m_selectedColor : m_deselectedColor, true);
    }

    private void OnSelected(bool _firstSelected)
        => ChangeColor(m_selectedColor, _firstSelected);

    private void OnDeselected()
        => ChangeColor(m_deselectedColor, false);

    private void ChangeColor(Color _color, bool _firstSelected)
    {
        if (_firstSelected)
        {
            m_image.color = _color;
            return;
        }
        
        if(m_tween is { active: true }) { m_tween.Kill(); }
        
        m_tween = DOTween.To(() => m_image.color, value => m_image.color = value, _color, m_fadeDuration).SetEase(m_fadeEase);
    }
}
