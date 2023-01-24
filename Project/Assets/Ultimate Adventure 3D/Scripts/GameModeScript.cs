using SimpleFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class GameModeScript : MonoBehaviour
{
    private bool m_paused = false;

    /// <summary>
    /// Постановка игры на паузу.
    /// </summary>
    public UnityEvent Pause;

    /// <summary>
    /// Продолжение игры.
    /// </summary>
    public UnityEvent Play;

    /// <summary>
    /// Update выполняется каждый кадр.
    /// </summary>
    private void Update()
    {
        if (!m_paused && Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
            return;
        }
        if (m_paused && Input.GetKeyDown(KeyCode.Escape))
        {
            SetPlay();
            return;
        }
    }

    /// <summary>
    /// Постановка игры на паузу.
    /// </summary>
    public void SetPause()
    {
        m_paused = true;
        Time.timeScale = 0;
        if (Pause != null) Pause.Invoke();
    }

    /// <summary>
    /// Возврат обратно в игру.
    /// </summary>
    public void SetPlay()
    {
        m_paused = false;
        Time.timeScale = 1;
        if (Play != null) Play.Invoke();
    }
}
