using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    private int m_keysCount;

    /// <summary>
    /// Событие изменения количества ключей в сумке.
    /// </summary>
    public UnityEvent KeysChange;

    /// <summary>
    /// Прибавление ключей.
    /// </summary>
    public void AddKeys(int count)
    {
        m_keysCount += count;
        if(KeysChange != null) KeysChange.Invoke();
    }

    /// <summary>
    /// Вычитание ключей.
    /// </summary>
    public bool SubstractKeys(int count)
    {
        if (m_keysCount < count) return false;
        m_keysCount -= count;
        if (KeysChange != null) KeysChange.Invoke();
        return true;
    }

    /// <summary>
    /// Получить количество ключей.
    /// </summary>
    public int GetKeysCount()
    {
        return m_keysCount;
    }
}
