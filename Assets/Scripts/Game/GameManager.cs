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
        gameScreen = screen;
        gameAI = new GameAI();
        matrix = ruleMatrix;
        isActive = true;
        streak = 0;
    }

    public int ExecuteTurn(string playerSign)
    {
        if(!isActive) return -1;

        string aiMove = gameAI.GetNextMove();
        Debug.Log("Ai move : " + aiMove);
        int result =  matrix.Execute(playerSign, aiMove);
        if(result == 1)
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
        EventDataInt gameState = new EventDataInt();
        gameState.value = 0;
        EventManager.Instance.TriggerEvent("game-state" , gameState);
    }

    public bool IsActive()
    {
        return isActive;
    }
}
