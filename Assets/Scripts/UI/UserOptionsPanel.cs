using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserOptionsPanel : MonoBehaviour
{
    public void OnClick(string id)
    {
        Debug.Log(GameManager.Instance.ExecuteTurn(id));
    }
}
