using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAI 
{
    List<string> validMoves = new List<string>{Signs.rock, Signs.paper, Signs.scissor, Signs.lizard, Signs.spock};
    public string GetNextMove()
    {
        return validMoves[Random.Range(0,validMoves.Count-1)];
    }
}