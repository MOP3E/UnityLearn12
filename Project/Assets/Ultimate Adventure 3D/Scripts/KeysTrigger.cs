using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Проверка, есть ли у персонажа нужное количество ключей.
/// </summary>
public class KeysTrigger : MonoBehaviour
{
    /// <summary>
    /// Количество ключей, которое нужно проверить.
    /// </summary>
    [SerializeField] private int m_keysCount;

    /// <summary>
    /// Текст, который нужно включить в случае неудачи.
    /// </summary>
    [SerializeField] private GameObject m_text;

    /// <summary>
    /// Событие с ключами уже сработало, повторно не вызывать!
    /// </summary>
    private bool m_isTriggered;

    /// <summary>
    /// Событие удаления ключей из сумки персонажа.
    /// </summary>
    public UnityEvent KeysRemoved;

    private void Start()
    {
        m_isTriggered = false;
    }

    /// <summary>
    /// Попытка удалить ключи из сумки.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (m_isTriggered) return;

        if (other == null) return;
        Bag bag = other.GetComponent<Bag>();
        if (bag == null) return;

        if (bag.SubstractKeys(m_keysCount))
        {
            m_isTriggered = true;
            if(KeysRemoved != null) KeysRemoved.Invoke();
        }
        else
            m_text.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        m_text.SetActive(false);
    }
}
