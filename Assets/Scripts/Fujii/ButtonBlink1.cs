using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBlink1 : MonoBehaviour
{
    public void OnClickStartButtonToBattle()
    {
        SceneManager.LoadScene("BattleDemo");
    }

    public void OnClickStartButtonToCraft()
    {
        SceneManager.LoadScene("Craft");
    }

    public void OnClickStartButtonToDeck()
    {
        SceneManager.LoadScene("Deck");
    }
}
