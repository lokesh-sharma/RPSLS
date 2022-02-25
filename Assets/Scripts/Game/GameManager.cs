using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    RuleMatrix matrix;
    bool isActive;
    GameAI gameAI;
    GameScreen gameScreen;

    int streak;

    public void StartGame(RuleMatrix ruleMatrix, GameScreen screen)
    {
        gameAI = new GameAI();
        matrix = ruleMatrix;
        isActive = true;
        streak = 0;
        gameScreen = screen;
        gameScreen.StartGame();
    }

    public int ExecuteTurn(string playerSign)
    {
        if(!isActive) return -1;

        string aiMove = gameAI.GetNextMove();
        int result =  matrix.Execute(playerSign, aiMove);
        LastRoundResult lastRoundResult = new LastRoundResult(playerSign, aiMove, result);
        gameScreen.NextRound(lastRoundResult);
        if(result == 1 || result == 0)
        {
            streak++;
        }
        else if (result == 2)
        {
            EndGame();
        }
        
        return result;
    }

    public void EndGame()
    {
        UserManager.Instance.UpdateHighScore(streak);
        matrix = null;
        isActive = false;
        streak = 0;
        gameAI = null;
        gameScreen.EndGame();
        gameScreen = null;
        EventManager.Instance.TriggerEvent("game-over");
    }

    public bool IsActive()
    {
        return isActive;
    }
}
