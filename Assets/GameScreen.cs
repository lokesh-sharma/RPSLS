using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    public void EndGame()
    {
        this.gameObject.SetActive(false);
    }
}
