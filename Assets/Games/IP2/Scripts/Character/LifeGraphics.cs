using DG.Tweening;
using UnityEngine;
using CharacterInfo = IP2.Character.CharacterInfo;

namespace IP2
{
    [RequireComponent(typeof(CharacterInfo))]
    public class LifeGraphics : MonoBehaviour
    {
        private CharacterInfo m_character;
        
        [SerializeField] private GameObject m_aliveGraphic;
        [SerializeField] private GameObject m_deadGraphic;

        [SerializeField] private Vector3 m_deadGraphicPunchAmount = Vector3.one;
        [SerializeField] private float m_deadGraphicPunchDuration = 1.0f;
        [SerializeField] private int m_deadGraphicPunchVibrato = 10;
        [SerializeField] private float m_deadGraphicPunchElasticity = 1.0f;

        private Tween m_punchTween;
        
        private void Awake()
        {
            m_character = GetComponent<CharacterInfo>();

            m_character.OnLifeChanged += OnLifeChanged;
        }

        private void OnLifeChanged(bool _alive)
        {
            m_aliveGraphic.SetActive(_alive);
            m_deadGraphic.SetActive(!_alive);

            if (!_alive) { DeathAnimation(); }
        }

        private void DeathAnimation()
        {
            if (m_punchTween is { active: true })
            {
                m_punchTween.Kill();
                m_deadGraphic.transform.localScale = Vector3.one;
            }

            m_punchTween = m_deadGraphic.transform.DOPunchScale(m_deadGraphicPunchAmount, m_deadGraphicPunchDuration, m_deadGraphicPunchVibrato, m_deadGraphicPunchElasticity);
        }
    }
}
