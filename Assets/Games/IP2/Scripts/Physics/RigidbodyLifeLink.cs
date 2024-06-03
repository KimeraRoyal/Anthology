using UnityEngine;
using CharacterInfo = IP2.Character.CharacterInfo;

public class RigidbodyLifeLink : MonoBehaviour
{
    private CharacterInfo m_character;
    
    private Rigidbody2D m_rigidbody;

    private void Awake()
    {
        m_character = GetComponent<CharacterInfo>();
        
        m_rigidbody = GetComponent<Rigidbody2D>();
        
        m_character.OnLifeChanged += OnLifeChanged;
    }

    private void OnLifeChanged(bool _alive)
    {
        m_rigidbody.simulated = _alive;
    }
}
