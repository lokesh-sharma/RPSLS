using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UserOptionsPanel : MonoBehaviour
{
    const float MAX_TURN_TIME = 2.0f;
    const float TIMER_BAR_WIDTH = 500.0f;

    const float TIMER_BAR_HEIGHT = 20.0f;
    float turnTimer = MAX_TURN_TIME;

    public Image timerBar;
    public Text timeText;

    Vector3 orgPos;
    void Start()
    {
        orgPos = transform.position;
    }
    public void OnClick(string id)
    {
        turnTimer = MAX_TURN_TIME;
        Hide();
        GameManager.Instance.ExecuteTurn(id);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
        turnTimer = MAX_TURN_TIME;
        timerBar.rectTransform.sizeDelta = new Vector2( turnTimer/MAX_TURN_TIME*TIMER_BAR_WIDTH, TIMER_BAR_HEIGHT);

        Vector3 pos = new Vector3(orgPos.x,-200,0);
        transform.position = pos;
        transform.DOMoveY(0,0.25f);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if(!GameManager.Instance.IsActive()) return;

        turnTimer -= Time.deltaTime;
        timeText.text = Mathf.CeilToInt(turnTimer).ToString() + " secs";
        if(turnTimer <= 0)
        {
            GameManager.Instance.EndGame();
        }

        timerBar.rectTransform.sizeDelta = new Vector2( turnTimer/MAX_TURN_TIME*TIMER_BAR_WIDTH, TIMER_BAR_HEIGHT);
    }
}
