using SimpleFPS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Телепортация игрока в телепорте.
/// </summary>
public class Teleporter : MonoBehaviour
{
    /// <summary>
    /// Целевой телепорт.
    /// </summary>
    [SerializeField] private Teleporter m_destination;

    /// <summary>
    /// Телепорт является приёмником.
    /// </summary>
    [HideInInspector] public bool IsDestination;

    /// <summary>
    /// Звук телепортера.
    /// </summary>
    private AudioSource m_source;

    /// <summary>
    /// Инициализация переменных.
    /// </summary>
    private void Start()
    {
        IsDestination = false;
        m_source = GetComponent<AudioSource>();
    }
    
    /// <summary>
    /// Событие входа игрока в телепортер.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (IsDestination || m_destination == null || other == null) return;
        FirstPersonController firstPersonController = other.GetComponent<FirstPersonController>();
        if (firstPersonController == null) return;

        //пометить телепорт-приёмник как приёмник и переместиться в него
        m_destination.IsDestination = true;
        firstPersonController.transform.position = m_destination.transform.position;
        m_source.Play();
    }

    /// <summary>
    /// Событие выхода игрока из телепортера.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other == null) return;
        FirstPersonController firstPersonController = other.GetComponent<FirstPersonController>();
        if (firstPersonController == null) return;

        //сбросить собственный флаг приёмника
        IsDestination = false;
    }
}
