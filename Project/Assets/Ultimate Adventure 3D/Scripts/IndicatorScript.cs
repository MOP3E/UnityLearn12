using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorScript : MonoBehaviour
{
    /// <summary>
    /// Материал включенного индикатора.
    /// </summary>
    [SerializeField] private Material m_onMaterial;

    /// <summary>
    /// Материал отключенного индикатора.
    /// </summary>
    [SerializeField] private Material m_offMaterial;

    /// <summary>
    /// Состояние индикатора.
    /// </summary>
    [SerializeField] private bool m_state;

    [SerializeField] private Renderer m_renderer;

    private void Start()
    {
        SetMaterial();
    }

    /// <summary>
    /// Включить индикатор.
    /// </summary>
    public void On()
    {
        m_state = true;
        SetMaterial();
    }

    /// <summary>
    /// Отключить индикатор.
    /// </summary>
    public void Off()
    {
        m_state = false;
        SetMaterial();
    }

    /// <summary>
    /// Получить состояние индикатора.
    /// </summary>
    /// <returns></returns>
    public bool GetState()
    {
        return m_state;
    }

    /// <summary>
    /// Установить материал в зависимости от состояния индикатора.
    /// </summary>
    private void SetMaterial()
    {
        if (m_renderer == null) return;
        m_renderer.material = m_state ? m_onMaterial : m_offMaterial;
    }
}
