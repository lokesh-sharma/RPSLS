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

        int hScore = UserManager.Instance.GetHighScore();
        highScore.text = "HighScore:\n" +  hScore;
        gameScreen.gameObject.SetActive(false);
    }

    public void OnClickPlay()
    {
        StandardRuleMatrix standardRuleMatrix = new StandardRuleMatrix();
        GameManager.Instance.StartGame(standardRuleMatrix, gameScreen);
        gameScreen.gameObject.SetActive(true);
    }
}
