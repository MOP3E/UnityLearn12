using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Зона, наносящая урон.
/// </summary>
public class DamageZone : MonoBehaviour
{
    /// <summary>
    /// Величина урона, который наносится разрушаемому объекту.
    /// </summary>
    [SerializeField] private int m_damage;

    /// <summary>
    /// Период, с которым наносится урон.
    /// </summary>
    [SerializeField] private float m_period;

    /// <summary>
    /// Источник звука для звука урона.
    /// </summary>
    [SerializeField] private AudioSource m_source;

    /// <summary>
    /// Список разрушаемых объектов, находящихся в зоне.
    /// </summary>
    private Destructible m_destructible;

    /// <summary>
    /// Время, прошедшее с начала периода.
    /// </summary>
    private float m_time;

    /// <summary>
    /// Добавление разрушаемого объекта в список при попадании его в зону.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        //получить ссылку на разрушаемый объект
        if (other == null) return;
        m_destructible = other.GetComponent<Destructible>();
        if(m_source != null) m_source.Play();
    }

    /// <summary>
    /// Удаление разрушаемого объекта из списка при выходе его из зоны.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        //получить ссылку на разрушаемый объект
        if (other == null) return;
        if (other.GetComponent<Destructible>() == m_destructible)
        {
            m_destructible = null;
            if (m_source != null) m_source.Stop();
        }
    }

    /// <summary>
    /// Нанесение урона разрушаемым объектам, находящимся в зоне.
    /// </summary>
    private void Update()
    {
        if (m_destructible == null) return;

        m_time += Time.deltaTime;
        if (m_time >= m_period)
        {
            m_time -= m_period;
            m_destructible.Hit(m_damage);
        }
    }
}
