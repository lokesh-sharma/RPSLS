using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public int highScore;
}

public class UserManager : Singleton<UserManager>
{
    User user;
    public void Initialize()
    {
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        user = new User();
        user.highScore = highScore;
    }

    public void UpdateHighScore(int newScore)
    {
        if(user.highScore < newScore)
        {
            Debug.Log(newScore);
            user.highScore = newScore;
            PlayerPrefs.SetInt("highScore", newScore);
        }
    }

    public int GetHighScore()
    {
        return user.highScore;
    }
}
