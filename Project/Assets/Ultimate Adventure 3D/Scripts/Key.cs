using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Поведение ключа.
/// </summary>
public class Key : Pickup
{
    /// <summary>
    /// Уничтожение ключа при столкновении с игроком и добавление его в сумку игрока.
    /// </summary>
    protected new void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        Bag bag = other.GetComponent<Bag>();
        //если у игрока нет сумки, он не может в неё сложить ключ, следовательно, ключ остаётся на поле нетронутым
        if (bag == null) return;

        //добавить ключ в мешок
        bag.AddKeys(1);

        DestroyObject();
    }
}
