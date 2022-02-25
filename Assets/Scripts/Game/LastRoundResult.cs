using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastRoundResult
{
    public string playerSign;
    public string aISign;
    public int result;

    public LastRoundResult(string p, string ai, int r)
    {
        playerSign = p;
        aISign = ai;
        result = r;
    }
}
