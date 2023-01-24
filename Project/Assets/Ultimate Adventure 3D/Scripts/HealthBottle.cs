using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Бутылка жизни.
/// </summary>
public class HealthBottle : Pickup
{
    /// <summary>
    /// Очки жизни, добавляемые к жизни персонажа при подъёме бутылки.
    /// </summary>
    [SerializeField] private int m_cure;

    /// <summary>
    /// Уничтожение бутылки жизни при столкновении с игроком и увеличение его счётчика жизни.
    /// </summary>
    protected new void OnTriggerEnter(Collider other)
    {
        Debug.Log("start");
        if (other == null) return;
        FirstPersonController firstPersonController = other.GetComponent<FirstPersonController>();
        if (firstPersonController == null) return;
        Debug.Log("firstPersonController");
        Destructible destructible = firstPersonController.GetComponent<Destructible>();
        if (destructible == null) return;
        Debug.Log("destructible");

        //добавить очки жизни к жизни персонажа и, если это сделано успешно - уничтожить бутылку
        if(destructible.Cure(m_cure)) DestroyObject();
    }
}
