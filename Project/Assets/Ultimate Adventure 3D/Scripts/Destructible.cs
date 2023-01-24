using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Разрушаемый объект.
/// </summary>
public class Destructible : MonoBehaviour
{
    /// <summary>
    /// Максимальное число очков жизни разрушаемого объекта.
    /// </summary>
    [SerializeField] private int m_maxHitpoints;

    /// <summary>
    /// Очки жизни разрушаемого объекта.
    /// </summary>
    private int m_hitpoints;

    /// <summary>
    /// Событие разрушения объекта.
    /// </summary>
    public UnityEvent Destruction;

    /// <summary>
    /// Событие изменения очков жизни персонажа.
    /// </summary>
    public UnityEvent HitpointsChange;

    /// <summary>
    /// Вызывается перед первым кадром.
    /// </summary>
    public void Start()
    {
        m_hitpoints = m_maxHitpoints;
    }

    /// <summary>
    /// Нанесение урона объекту.
    /// </summary>
    /// <param name="damage">Величина наносимого урона.</param>
    public void Hit(int damage)
    {
        m_hitpoints -= damage;
        if (m_hitpoints <= 0)
        {
            Kill();
        }
        else
        {
            if (HitpointsChange != null) HitpointsChange.Invoke();
        }
    }

    /// <summary>
    /// Лечение объекта.
    /// </summary>
    public bool Cure(int cure)
    {
        if (m_hitpoints >= m_maxHitpoints) return false;
        m_hitpoints += cure;
        if (m_hitpoints > m_maxHitpoints) m_hitpoints = m_maxHitpoints;
        if (HitpointsChange != null) HitpointsChange.Invoke();
        return true;
    }

    /// <summary>
    /// Гарантированное убийство объекта.
    /// </summary>
    public void Kill()
    {
        m_hitpoints = 0;
        if (HitpointsChange != null) HitpointsChange.Invoke();
        if (Destruction != null) Destruction.Invoke();
    }

    /// <summary>
    /// Получить число очков жизни.
    /// </summary>
    public int GetHitpoints()
    {
        return m_hitpoints;
    }

    /// <summary>
    /// Получить нормализованное число очков жизни.
    /// </summary>
    public float GetNormalizedHitpoints()
    {
        return m_hitpoints < m_maxHitpoints ? (float)m_hitpoints / (float)m_maxHitpoints : 1f;
    }
}
