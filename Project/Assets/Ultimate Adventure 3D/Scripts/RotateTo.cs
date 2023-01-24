using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Вращение до указанног угла.
/// </summary>
public class RotateTo : MonoBehaviour
{
    /// <summary>
    /// Скорость вращения, единиц/с.
    /// </summary>
    [SerializeField] private float m_speed;

    /// <summary>
    /// Угол, к которому нужно повернуть в градусах.
    /// </summary>
    [SerializeField] private Vector3 m_destination;

    /// <summary>
    /// Звук вращаемого объекта.
    /// </summary>
    [SerializeField] private AudioSource m_source;

    /// <summary>
    /// Угол назначения в кватерионах.
    /// </summary>
    private Quaternion m_destinationQ;

    /// <summary>
    /// Выполняется вращение.
    /// </summary>
    private bool m_work;

    /// <summary>
    /// Запуск вращения.
    /// </summary>
    public void StartRotation()
    {
        m_destinationQ = Quaternion.Euler(m_destination);
        m_work = true;
        if(m_source != null) m_source.Play();
    }

    /// <summary>
    /// Остановка вращения.
    /// </summary>
    public void StopRotation()
    {
        m_work = false;
        if(m_source != null) m_source.Stop();
    }

    /// <summary>
    /// Поворот объекта к нужному углу.
    /// </summary>
    private void Update()
    {
        if (!m_work) return;

        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, m_destinationQ, m_speed * Time.deltaTime);
        if(transform.localRotation == m_destinationQ) StopRotation();
    }
}
