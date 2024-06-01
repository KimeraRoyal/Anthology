namespace IP2
{
    public class EnableOnShow : Showable
    {
        private void Awake()
        {
            OnShow += () => { gameObject.SetActive(true); };
            OnHide += () => { gameObject.SetActive(false); };
        }

        private void Start()
        {
            gameObject.SetActive(Shown);
        }
    }
}
