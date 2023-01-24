using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Поднимание предмета игроком.
/// </summary>
public class Pickup : MonoBehaviour
{
    /// <summary>
    /// Эффект, вызываемый при подборе предмета.
    /// </summary>
    [SerializeField] protected GameObject m_impactEffect;

    /// <summary>
    /// Уничтожение объекта при столкновении с игроком.
    /// </summary>
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        FirstPersonController firstPersonController = other.GetComponent<FirstPersonController>();
        if (firstPersonController == null) return;

        DestroyObject();
    }

    /// <summary>
    /// Уничтожение объекта пристолкновении с персонажем.
    /// </summary>
    protected void DestroyObject()
    {
        //запустить эффект подбора ключа
        Instantiate(m_impactEffect);

        //уничтожить ключ
        Destroy(gameObject);
    }
}
