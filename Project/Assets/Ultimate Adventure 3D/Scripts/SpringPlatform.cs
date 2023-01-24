using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Подпрыгивание игрока на пружинной платформе.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SpringPlatform : MonoBehaviour
{
    /// <summary>
    /// Сила прыжка.
    /// </summary>
    [SerializeField] private int m_JumpForce;

    /// <summary>
    /// Подвижная платформа.
    /// </summary>
    [SerializeField] private GameObject m_platform;

    /// <summary>
    /// Положение включенной платформы.
    /// </summary>
    [SerializeField] private Vector3 m_onPosition;

    /// <summary>
    /// Положение выключенной платформы.
    /// </summary>
    [SerializeField] private Vector3 m_offPosition;

    /// <summary>
    /// Старая сила прыжка.
    /// </summary>
    private float m_OldJumpForce;

    /// <summary>
    /// Источник звука пружины.
    /// </summary>
    private AudioSource m_AudioSource;

    /// <summary>
    /// Состояние платформы.
    /// </summary>
    [SerializeField] private bool m_state;

    /// <summary>
    /// Выполняется перед первым кадром.
    /// </summary>
    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        MovePlatform();
    }

    /// <summary>
    /// Ускорение игрока при входе в ускоритель.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        FirstPersonController firstPersonController = other.GetComponent<FirstPersonController>();
        if (firstPersonController == null) return;

        m_OldJumpForce = firstPersonController.m_JumpSpeed;

        //если платформа отключена - не прыгать
        if (!m_state) return;

        firstPersonController.m_JumpSpeed += m_JumpForce;
        firstPersonController.m_Jump = true;

        if(m_AudioSource != null) m_AudioSource.Play();
    }

    /// <summary>
    /// Торможение игрока при выходе из ускорителя.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other == null) return;
        FirstPersonController firstPersonController = other.GetComponent<FirstPersonController>();
        if (firstPersonController == null) return;

        firstPersonController.m_JumpSpeed = m_OldJumpForce;
    }

    /// <summary>
    /// Включить индикатор.
    /// </summary>
    public void On()
    {
        m_state = true;
        MovePlatform();
    }

    /// <summary>
    /// Отключить индикатор.
    /// </summary>
    public void Off()
    {
        m_state = false;
        MovePlatform();
    }

    private void MovePlatform()
    {
        if (m_platform == null) return;
        m_platform.transform.localPosition = m_state ? m_onPosition : m_offPosition;
    }
}
