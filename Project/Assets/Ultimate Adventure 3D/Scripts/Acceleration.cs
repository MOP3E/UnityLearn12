using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ускорение игрока в зоне ускорителя.
/// </summary>
public class Acceleration : MonoBehaviour
{
    [SerializeField] private int m_Speedup;

    /// <summary>
    /// Ускорение игрока при входе в ускоритель.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        FirstPersonController firstPersonController = other.GetComponent<FirstPersonController>();
        if (firstPersonController == null) return;

        firstPersonController.m_WalkSpeed += m_Speedup;
        firstPersonController.m_RunSpeed += m_Speedup;
        firstPersonController.m_JumpSpeed += m_Speedup;
    }


    /// <summary>
    /// Торможение игрока при выходе из ускорителя.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other == null) return;
        FirstPersonController firstPersonController = other.GetComponent<FirstPersonController>();
        if (firstPersonController == null) return;

        firstPersonController.m_WalkSpeed -= m_Speedup;
        firstPersonController.m_RunSpeed -= m_Speedup;
        firstPersonController.m_JumpSpeed -= m_Speedup;
    }
}
