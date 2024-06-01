using UnityEngine;

namespace IP2.Graphics.SpriteAnimation
{
    public abstract class SpriteAnimationSet : ScriptableObject, ISpriteAnimationSet
    {
        public abstract SpriteAnimation GetAnimation(int _index);
        public abstract int GetAnimationCount();
        public abstract int GetFirstAnimationIndex();
    }
}