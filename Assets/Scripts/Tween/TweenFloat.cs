using System;
using DG.Tweening;
using DG.Tweening.Core;

namespace Anthology
{
    [Serializable]
    public class TweenFloat : TweenValue<float>
    {
        protected override Tween AnimateTemplate(DOGetter<float> _getter, DOSetter<float> _setter, float _target, float _duration)
            => DOTween.To(_getter, _setter, _target, _duration);
    }
}
