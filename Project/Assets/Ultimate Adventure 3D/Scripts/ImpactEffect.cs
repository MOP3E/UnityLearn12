using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    /// <summary>
    /// Время жизни эффекта.
    /// </summary>
    [SerializeField] private float m_lifeTime;

    private void Start()
    {
        //уничтожить эффект по истечении заданного времени жизни
        Destroy(gameObject, m_lifeTime);
    }
}
