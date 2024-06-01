namespace IP3.Graphics.Show
{
    public class ShowLinkParent : Showable
    {
        private ShowLinkChild[] m_children;

        private void Awake()
        {
            m_children = GetComponentsInChildren<ShowLinkChild>();

            OnShow += ShowChildren;
            OnHide += HideChildren;
        }

        private void ShowChildren()
        {
            foreach (var child in m_children)
            {
                child.Showable.Show();
            }
        }

        private void HideChildren()
        {
            foreach (var child in m_children)
            {
                child.Showable.Hide();
            }
        }
    }
}
