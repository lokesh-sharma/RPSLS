﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Signs
{
    public static string rock = "rock";
    public static string paper = "paper";
    public static string scissor = "scissor";
    public static string lizard = "lizard";
    public static string spock = "spock";

}

public abstract class RuleMatrix
{
    public abstract int Execute(string player1Move, string player2Move);
}

public class GameAI 
{
    List<string> validMoves = new List<string>{Signs.rock, Signs.paper, Signs.scissor, Signs.lizard, Signs.spock};
    public string GetNextMove()
    {
        return validMoves[Random.Range(0,validMoves.Count-1)];
    }
}

public class StandardRuleMatrix : RuleMatrix
{
	Dictionary<string, int> rules;

	public StandardRuleMatrix() {
		rules = new Dictionary<string, int> ();
		rules.Add(Signs.rock + Signs.rock, 0);
        rules.Add(Signs.rock + Signs.paper, 2);
        rules.Add(Signs.rock + Signs.scissor, 1);
        rules.Add(Signs.rock + Signs.lizard, 1);
        rules.Add(Signs.rock + Signs.spock, 2);

        rules.Add(Signs.paper + Signs.rock, 1);
        rules.Add(Signs.paper + Signs.paper, 0);
        rules.Add(Signs.paper + Signs.scissor, 2);
        rules.Add(Signs.paper + Signs.lizard, 2);
        rules.Add(Signs.paper + Signs.spock, 1);

        rules.Add(Signs.scissor + Signs.rock, 2);
        rules.Add(Signs.scissor + Signs.paper, 1);
        rules.Add(Signs.scissor + Signs.scissor, 0);
        rules.Add(Signs.scissor + Signs.lizard, 1);
        rules.Add(Signs.scissor + Signs.spock, 2);

        rules.Add(Signs.lizard + Signs.rock, 2);
        rules.Add(Signs.lizard + Signs.paper, 1);
        rules.Add(Signs.lizard + Signs.scissor, 2);
        rules.Add(Signs.lizard + Signs.lizard, 0);
        rules.Add(Signs.lizard + Signs.spock, 1);

        rules.Add(Signs.spock + Signs.rock, 1);
        rules.Add(Signs.spock + Signs.paper, 2);
        rules.Add(Signs.spock + Signs.scissor, 1);
        rules.Add(Signs.spock + Signs.lizard, 2);
        rules.Add(Signs.spock + Signs.spock, 0);

	}

    public override int Execute(string p1, string p2)
    {
        return rules.ContainsKey(p1+p2) ? rules[p1+p2] : -1;
    }

}
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
    }
}
