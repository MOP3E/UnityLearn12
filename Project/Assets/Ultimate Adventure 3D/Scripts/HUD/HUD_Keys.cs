using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Keys : MonoBehaviour
{
    [SerializeField] private Bag m_bag;
    [SerializeField] private Text m_text;

    private void Start()
    {
        m_bag.KeysChange.AddListener(Redraw);
    }

    private void OnDestroy()
    {
        m_bag.KeysChange.RemoveListener(Redraw);
    }

    /// <summary>
    /// Обновление величины индикатора очков жизни.
    /// </summary>
    public void Redraw()
    {
        m_text.text = m_bag.GetKeysCount().ToString();
    }
}
