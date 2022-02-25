using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserOptionsPanel : MonoBehaviour
{
    void Start()
    {
        StandardRuleMatrix standardRuleMatrix = new StandardRuleMatrix();
        GameManager.Instance.StartGame(standardRuleMatrix);
    }

    public void OnClick(string id)
    {
        Debug.Log(GameManager.Instance.ExecuteTurn(id));
    }
}
