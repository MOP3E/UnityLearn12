using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Зона, которая убивает.
/// </summary>
public class KillZone : MonoBehaviour
{
    /// <summary>
    /// Убийство объекта при попадании в зону.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        Destructible destructible = other.GetComponent<Destructible>();
        if (destructible == null) return;

        destructible.Kill();
    }
}
