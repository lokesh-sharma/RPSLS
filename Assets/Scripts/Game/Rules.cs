using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RuleMatrix
{
    public abstract int Execute(string player1Move, string player2Move);
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