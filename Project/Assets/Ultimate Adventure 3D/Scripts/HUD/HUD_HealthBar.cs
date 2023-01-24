using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Нашлемный индикатор очков жизни.
/// </summary>
public class HUD_HealthBar : MonoBehaviour
{
    [SerializeField] private Destructible m_destructible;
    [SerializeField] private Image m_image;

    private void Start()
    {
        m_destructible.HitpointsChange.AddListener(Redraw);
    }

    private void OnDestroy()
    {
        m_destructible.HitpointsChange.RemoveListener(Redraw);
    }

    /// <summary>
    /// Обновление величины индикатора очков жизни.
    /// </summary>
    public void Redraw()
    {
        m_image.fillAmount = m_destructible.GetNormalizedHitpoints();
    }
}
