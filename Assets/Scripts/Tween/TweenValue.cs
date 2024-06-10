using System;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

namespace Anthology
{
    [Serializable]
    public abstract class TweenValue<T>
    {
        [SerializeField] private T m_target;
        
        [SerializeField] private float m_duration = 1.0f;
        [SerializeField] private Ease m_ease = Ease.Linear;

        public Tween Animate(DOGetter<T> _getter, DOSetter<T> _setter)
            => AnimateTemplate(_getter, _setter, m_target, m_duration).SetEase(m_ease);

        protected abstract Tween AnimateTemplate(DOGetter<T> _getter, DOSetter<T> _setter, T _target, float _duration);
    }
}
