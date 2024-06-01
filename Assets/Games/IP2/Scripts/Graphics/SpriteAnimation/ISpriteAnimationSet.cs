namespace IP2.Graphics.SpriteAnimation
{
    public interface ISpriteAnimationSet
    {
        public SpriteAnimation GetAnimation(int _index);
        public int GetAnimationCount();

        public int GetFirstAnimationIndex();
    }
}