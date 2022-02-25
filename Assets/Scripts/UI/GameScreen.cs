using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameScreen : MonoBehaviour
{
    public UserOptionsPanel userOptionsPanel;
    public Transform playerContainer;
    public Text playerSign;
    public Text aiSign;
    public Text winner;

    public void StartGame()
    {
        winner.text = "";
        playerContainer.gameObject.SetActive(false);
        userOptionsPanel.Show();
    }
    public void EndGame()
    {
        userOptionsPanel.Hide();
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(2.0f).AppendCallback(()=>{
            this.gameObject.SetActive(false);
        });
    }

    public void NextRound(LastRoundResult lastRoundResult)
    {
        playerSign.text = lastRoundResult.playerSign;
        aiSign.text = lastRoundResult.aISign;

        if(lastRoundResult.result == 0)
        {
            winner.text = "It's a tie";
        }
        else if(lastRoundResult.result == 1)
        {
            winner.text = "You Won!!";
        }
        else
        {
            winner.text = "Shelbot Won!!\nGame Over";
        }

        playerContainer.gameObject.SetActive(true);
        foreach(Transform t in playerContainer)
        {
            t.DOPunchScale(new Vector3(1.01f, 1.01f, 1.0f), 0.15f);
        }
        
        userOptionsPanel.Show();
    }
}
