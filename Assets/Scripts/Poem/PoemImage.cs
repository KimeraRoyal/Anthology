using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PoemImage : MonoBehaviour
{
    private PoemSwitcher m_switcher;

    private Image m_image;

    private void Awake()
    {
        m_switcher = GetComponentInParent<PoemSwitcher>();
        
        m_image = GetComponent<Image>();
        
        m_switcher.OnPoemChanged.AddListener(UpdateImage);
    }

    private void Start()
        => UpdateImage(m_switcher.Poem);

    private void UpdateImage(Poem _poem)
        => m_image.sprite = _poem?.Image;
}
