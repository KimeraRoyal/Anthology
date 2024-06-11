using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoemSwitcher : MonoBehaviour
{
    [SerializeField] private Poem[] m_poems;

    private Dictionary<string, Poem> m_poemDictionary;
    
    private Poem m_selectedPoem;

    public Poem Poem
    {
        get => m_selectedPoem;
        private set
        {
            if(m_selectedPoem == value) { return; }

            m_selectedPoem = value;
            
            OnPoemChanged?.Invoke(m_selectedPoem);
        }
    }

    public UnityEvent<Poem> OnPoemChanged;

    private void Awake()
    {
        m_poemDictionary = new Dictionary<string, Poem>();
        foreach (var poem in m_poems)
        {
            m_poemDictionary.Add(poem.name, poem);
        }
    }

    public void ShowPoem(string _name)
        => Poem = m_poemDictionary[_name];
}
