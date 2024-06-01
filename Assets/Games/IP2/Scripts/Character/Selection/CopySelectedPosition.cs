using IP2.Character.Selection;
using UnityEngine;
using CharacterInfo = IP2.Character.CharacterInfo;

namespace IP2
{
    public class CopySelectedPosition : MonoBehaviour
    {
        private Selector m_selector;

        [SerializeField] private Vector3 m_factor = Vector3.one;
        [SerializeField] private Vector3 m_offset;

        private void Awake()
        {
            m_selector = FindObjectOfType<Selector>();
        }

        private void Start()
        {
            m_selector.OnCharacterSelected += OnCharacterSelected;

            OnCharacterSelected(m_selector.SelectedCharacter);
        }

        private void OnCharacterSelected(CharacterInfo _character)
        {
             if(!_character) { return; }

             var position = _character.transform.position;
             transform.position = new Vector3(position.x * m_factor.x, position.y * m_factor.y, position.z * m_factor.z) + m_offset;
        }
    }
}
