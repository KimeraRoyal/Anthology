using System;
using IP3;
using UnityEngine;

public class StatBarFill : MonoBehaviour
{
    private StatBar m_statBar;

    private DollStat m_stat;

    [SerializeField] private float m_fillChangeTime = 1.0f;

    private float m_fillPercentage;
    private float m_velocity;

    private void Awake()
    {
        m_statBar = GetComponentInParent<StatBar>();
            
        m_statBar.OnStatChanged += OnStatChanged;
    }

    private void Update()
    {
        var currentFill = transform.localScale.x;
        currentFill = Mathf.SmoothDamp(currentFill, m_fillPercentage, ref m_velocity, m_fillChangeTime);
        UpdateFill(currentFill);
    }

    private void OnStatChanged(DollStat _stat)
    {
        if (m_stat != null) { m_stat.OnValueChanged -= OnStatValueChanged; }
        
        m_stat = _stat;
        m_fillPercentage = GetFillPercentage(m_stat.Value, m_stat.Stat.Min, m_stat.Stat.Max);
        UpdateFill(m_fillPercentage);
        
        m_stat.OnValueChanged += OnStatValueChanged;
    }

    private void OnStatValueChanged(float _value)
        => m_fillPercentage = GetFillPercentage(Mathf.Clamp(_value, m_stat.Stat.Min, m_stat.Stat.Max), m_stat.Stat.Min, m_stat.Stat.Max);

    private void UpdateFill(float _percentage)
        => transform.localScale = new Vector3(_percentage, 1.0f, 1.0f);

    private static float GetFillPercentage(float _value, float _min, float _max)
    {
        var fillPercentage = 0.0f;
        if(_max - _min > 0.001f) { fillPercentage = (_value - _min) / (_max - _min); }
        return fillPercentage;
    }
}
