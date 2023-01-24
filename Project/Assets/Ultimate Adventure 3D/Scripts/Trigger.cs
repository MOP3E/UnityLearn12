using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Взаимодействие игрока с триггером.
/// </summary>
public class Trigger : MonoBehaviour
{
    /// <summary>
    /// Событие нажатия на кнопку.
    /// </summary>
    public UnityEvent OnEnter;

    /// <summary>
    /// Событие отпускания кнопки.
    /// </summary>
    public UnityEvent OnExit;

    /// <summary>
    /// Событие появления игрока в триггере.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        FirstPersonController firstPersonController = other.GetComponent<FirstPersonController>();
        if (firstPersonController == null) return;

        if(OnEnter != null) OnEnter.Invoke();
    }

    /// <summary>
    /// Событие выхода игрока из триггера.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other == null) return;
        FirstPersonController firstPersonController = other.GetComponent<FirstPersonController>();
        if (firstPersonController == null) return;

        if (OnExit != null) OnExit.Invoke();
    }
}
