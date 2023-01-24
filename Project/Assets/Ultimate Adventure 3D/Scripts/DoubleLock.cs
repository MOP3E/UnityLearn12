using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Двойной замок.
/// </summary>
public class DoubleLock : MonoBehaviour
{
    /// <summary>
    /// Левый ключ.
    /// </summary>
    private bool m_leftKey = false;

    /// <summary>
    /// Левый ключ.
    /// </summary>
    private bool m_rightKey = false;

    /// <summary>
    /// Событие открытия замка.
    /// </summary>
    public UnityEvent Unlock;

    /// <summary>
    /// Открыть левый ключ.
    /// </summary>
    public void LeftKeyOpen()
    {
        m_leftKey = true;
        if(m_leftKey && m_rightKey && Unlock != null) Unlock.Invoke();
    }

    /// <summary>
    /// Открыть правый ключ.
    /// </summary>
    public void RightKeyOpen()
    {
        m_rightKey = true;
        if (m_leftKey && m_rightKey && Unlock != null) Unlock.Invoke();
    }
}
