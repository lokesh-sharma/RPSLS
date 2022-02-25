using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserOptionsPanel : MonoBehaviour
{
    const float MAX_TURN_TIME = 2.0f;
    const float TIMER_BAR_WIDTH = 500.0f;

    const float TIMER_BAR_HEIGHT = 20.0f;
    float turnTimer = MAX_TURN_TIME;

    public Image timerBar;
    public void OnClick(string id)
    {
        turnTimer = MAX_TURN_TIME;
        Debug.Log(GameManager.Instance.ExecuteTurn(id));
    }

    void OnEnable()
    {
        EventManager.Instance.StartListening("game-state" , OnGameStateChanged);
    }

    void OnDisable()
    {
        EventManager.Instance.StopListening("game-state" , OnGameStateChanged);
    }

    void FixedUpdate()
    {
        if(!GameManager.Instance.IsActive()) return;

        turnTimer -= Time.deltaTime;
        if(turnTimer <= 0)
        {
            GameManager.Instance.EndGame();
        }

        timerBar.rectTransform.sizeDelta = new Vector2( turnTimer/MAX_TURN_TIME*TIMER_BAR_WIDTH, TIMER_BAR_HEIGHT);
    }

    void OnGameStateChanged(EventData data)
    {
        EventDataInt eventData = data as EventDataInt;
        
        turnTimer = MAX_TURN_TIME;
        timerBar.rectTransform.sizeDelta = new Vector2( turnTimer/MAX_TURN_TIME*TIMER_BAR_WIDTH, TIMER_BAR_HEIGHT);
    }
}
