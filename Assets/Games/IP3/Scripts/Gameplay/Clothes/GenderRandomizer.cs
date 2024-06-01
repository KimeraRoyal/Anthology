using IP3.Gameplay.Clothes;
using UnityEngine;

namespace IP3
{
    public class GenderRandomizer : MonoBehaviour
    {
        private DollStat m_stat;
        
        [SerializeField] private string m_statName;
        
        private void Awake()
        {
            var attachmentPoints = GetComponentsInChildren<AttachmentPoint>();
            foreach (var attachmentPoint in attachmentPoints)
            {
                attachmentPoint.OnClothingAttached += RandomizeGender;
                attachmentPoint.OnClothingDetached += RandomizeGender;
            }
        }

        private void Start()
        {
            var dollStats = FindObjectOfType<DollStats>();
            m_stat = dollStats.StatDictionary[m_statName];
        }

        private void RandomizeGender(ClothingAttacher _clothing)
        {
            m_stat.Value = Random.Range(m_stat.Stat.Min, m_stat.Stat.Max);
        }
    }
}
