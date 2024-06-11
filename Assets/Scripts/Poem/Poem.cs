using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Poem", menuName = "Title Screen/Poem")]
public class Poem : ScriptableObject
{
    [SerializeField] private string m_author;

    [SerializeField] private Sprite m_image;
    
    [Title("Poem")]
    [HideLabel] [MultiLineProperty(20)]
    [SerializeField] private string m_text;

    public string Author => m_author;

    public Sprite Image => m_image;
    public string Body => m_text;
}
