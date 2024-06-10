using System.Collections.Generic;
using UnityEngine;

public class PoemSwitcher : MonoBehaviour
{
    private PoemWindow m_window;
    
    [SerializeField] private Poem[] m_poems;

    private Dictionary<string, Poem> m_poemDictionary;

    private void Awake()
    {
        m_window = GetComponent<PoemWindow>();

        m_poemDictionary = new Dictionary<string, Poem>();
        foreach (var poem in m_poems)
        {
            m_poemDictionary.Add(poem.name, poem);
        }
    }

    public void ShowPoem(string _name)
    {
        m_window.Poem = m_poemDictionary[_name];
        m_window.Show();
    }
}
