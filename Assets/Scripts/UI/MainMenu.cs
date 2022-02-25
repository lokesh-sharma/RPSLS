using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameScreen gameScreen;
    public Text highScore;
    
    void Awake()
    {
        UserManager.Instance.Initialize();
    }
    void Start()
    {
        SetHighScore();
        gameScreen.gameObject.SetActive(false);
        EventManager.Instance.StartListening("game-over", UpdateHighScore);
    }

    public void OnClickPlay()
    {
        StandardRuleMatrix standardRuleMatrix = new StandardRuleMatrix();
        GameManager.Instance.StartGame(standardRuleMatrix, gameScreen);
        gameScreen.gameObject.SetActive(true);
    }

    void UpdateHighScore(EventData unused)
    {
        SetHighScore();
    }

    void SetHighScore()
    {
        int hScore = UserManager.Instance.GetHighScore();
        highScore.text = "HighScore:\n" +  hScore;
    }
}
