using UnityEngine;

namespace IP3
{
    public abstract class StatModifier : ScriptableObject
    {
        public abstract void OnAdded(DollStat _stat, float _factor);
        public abstract void OnRemoved(DollStat _stat, float _factor);
    }
}
