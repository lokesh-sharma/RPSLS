﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameScreen : MonoBehaviour
{
    public UserOptionsPanel userOptionsPanel;
    public Transform playerContainer;
    public GameObject initialState;
    public GameObject crownPlayer;
    public GameObject crownAI;
    public Text playerSign;
    public Text aiSign;
    public Text winner;

    public void StartGame()
    {
        initialState.SetActive(true);
        winner.text = "";
        playerContainer.gameObject.SetActive(false);
        userOptionsPanel.Show();
    }
    public void EndGame()
    {
        userOptionsPanel.Hide();
        Sequence seq = DOTween.Sequence();
        seq.AppendInterval(1.5f).AppendCallback(()=>{
            this.gameObject.SetActive(false);
        });
    }

    public void NextRound(LastRoundResult lastRoundResult)
    {
        initialState.SetActive(false);
        playerSign.text = lastRoundResult.playerSign;
        aiSign.text = lastRoundResult.aISign;
        crownPlayer.SetActive(false);
        crownAI.SetActive(false);

        if(lastRoundResult.result == 0)
        {
            winner.text = "It's a tie";
        }
        else if(lastRoundResult.result == 1)
        {
            crownPlayer.SetActive(true);
            winner.text = "You Won!!";
        }
        else
        {
            crownAI.SetActive(true);
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
