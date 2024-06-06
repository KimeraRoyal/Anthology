using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Poem", menuName = "Poem")]
public class Poem : ScriptableObject
{
    [SerializeField] private string m_author;
    
    [Title("Poem")]
    [HideLabel] [MultiLineProperty(20)]
    [SerializeField] private string m_text;
}
