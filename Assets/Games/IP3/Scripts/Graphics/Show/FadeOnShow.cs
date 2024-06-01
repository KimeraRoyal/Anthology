using DG.Tweening;
using IP3.Graphics.Colorable;
using UnityEngine;

namespace IP3.Graphics.Show
{
    public class FadeOnShow : Showable, IColorable
    {
        [SerializeField] private SpriteRenderer[] m_spriteRenderers;
        private Color[] m_originalColors;

        [SerializeField] private Gradient m_fadeGradient;

        [SerializeField] private bool m_adjustHsv;
        [SerializeField] private AnimationCurve m_hueCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
        [SerializeField] private AnimationCurve m_saturationCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
        [SerializeField] private AnimationCurve m_valueCurve = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);

        [SerializeField] private float m_fadeInDuration = 1.0f;
        [SerializeField] private Ease m_fadeInEase = Ease.Linear;
        
        [SerializeField] private float m_fadeOutDuration = 1.0f;
        [SerializeField] private Ease m_fadeOutEase = Ease.Linear;

        [SerializeField] private int m_colorableKey = -1;
        [SerializeField] private float m_colorableTime = 1.0f;

        private float m_fadePercentage;
        private bool m_colorsDirty;

        private Tween m_fadeTween;

        private float FadePercentage
        {
            get => m_fadePercentage;
            set
            {
                m_fadePercentage = value;
                m_colorsDirty = true;
            }
        }

        private void Awake()
        {
            if (m_spriteRenderers == null || m_spriteRenderers.Length < 1)
            {
                m_spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            }

            m_originalColors = new Color[m_spriteRenderers.Length];
            for(var i = 0; i < m_spriteRenderers.Length; i++)
            {
                m_originalColors[i] = m_spriteRenderers[i].color;
            }

            OnShow += () => { Fade(true); };
            OnHide += () => { Fade(false); };
        }

        private void Start()
        {
            FadePercentage = Shown ? 1.0f : 0.0f;
            UpdateColors();
        }

        private void Update()
        {
            UpdateColors();
        }

        private void Fade(bool _show)
        {
            if(m_fadeTween is { active: true }) { m_fadeTween.Kill(); }

            var fade = _show ? 1.0f : 0.0f;
            var duration = _show ? m_fadeInDuration : m_fadeOutDuration;
            var ease = _show ? m_fadeInEase : m_fadeOutEase;

            if (duration > 0.001f)
            {
                m_fadeTween = DOTween.To(() => FadePercentage, _value => FadePercentage = _value, fade, duration).SetEase(ease);
            }
            else
            {
                FadePercentage = fade;
            }
        }

        private void UpdateColors()
        {
            if(!m_colorsDirty) { return; }
            
            var color = m_fadeGradient.Evaluate(m_fadePercentage);
            color = AdjustHSV(color);
            
            for(var i = 0; i < m_spriteRenderers.Length; i++)
            {
                m_spriteRenderers[i].color = m_originalColors[i] * color;
            }

            m_colorsDirty = false;
        }

        private Color AdjustHSV(Color _color)
        {
            if (!m_adjustHsv) { return _color; }
            
            Color.RGBToHSV(_color, out var h, out var s, out var v);
            h = m_hueCurve.Evaluate(h);
            s = m_saturationCurve.Evaluate(s);
            v = m_valueCurve.Evaluate(v);
            return Color.HSVToRGB(h, s, v);
        }

        public void SetColor(Color _color)
        {
            if (m_colorableKey < 0) { return; }
            
            var colorKeys = m_fadeGradient.colorKeys;
            colorKeys[m_colorableKey] = new GradientColorKey(_color, m_colorableTime);
            m_fadeGradient.SetKeys(colorKeys, m_fadeGradient.alphaKeys);
        }
    }
}
