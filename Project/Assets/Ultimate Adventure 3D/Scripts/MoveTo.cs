using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Движение в указанную точку.
/// </summary>
public class MoveTo : MonoBehaviour
{
    /// <summary>
    /// Скорость движения, единиц/с.
    /// </summary>
    [SerializeField] private float m_speed;

    /// <summary>
    /// Точка, в которую нужно переместиться.
    /// </summary>
    [SerializeField] private Transform m_destination;

    /// <summary>
    /// Звук двигаемого объекта.
    /// </summary>
    [SerializeField] private AudioSource m_source;

    /// <summary>
    /// Выполняется движение.
    /// </summary>
    private bool m_work;

    /// <summary>
    /// Запуск движения.
    /// </summary>
    public void StartMoving()
    {
        m_work = true;
        if (m_source != null) m_source.Play();
    }

    /// <summary>
    /// Остановка движения.
    /// </summary>
    public void StopMoving()
    {
        m_work = false;
        if (m_source != null) m_source.Stop();
    }

    /// <summary>
    /// Перемещение объекта в заданную точку.
    /// </summary>
    private void Update()
    {
        if (!m_work) return;

        transform.position = Vector3.MoveTowards(transform.position, m_destination.position, m_speed * Time.deltaTime);
        if(transform.position == m_destination.position) StopMoving();
    }
}
