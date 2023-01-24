using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerScript : MonoBehaviour
{
    /// <summary>
    /// Время работы таймера.
    /// </summary>
    private float m_time;

    /// <summary>
    /// Текущее время таймера.
    /// </summary>
    private float m_currentTime;

    /// <summary>
    /// Звук работы таймера.
    /// </summary>
    [SerializeField] AudioSource m_audioSource;

    /// <summary>
    /// Событие завершения работы таймера.
    /// </summary>
    [SerializeField] private UnityEvent m_timerComplete;

    /// <summary>
    /// Таймер работает.
    /// </summary>
    private bool m_work;

    /// <summary>
    /// Запуск таймера на заданное время.
    /// </summary>
    public void StartTimer(float time)
    {
        m_time = time;
        m_currentTime = 0;
        m_work = true;
        if (m_audioSource != null) m_audioSource.Play();
    }

    /// <summary>
    /// Работа таймера.
    /// </summary>
    private void Update()
    {
        if (!m_work) return;

        m_currentTime += Time.deltaTime;
        if (m_currentTime < m_time) return;

        m_work = false;
        if (m_audioSource != null) m_audioSource.Stop();
        if(m_timerComplete != null) m_timerComplete.Invoke();
    }
}
