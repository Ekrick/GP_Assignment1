using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Text _winnerText;

    public void WinnerText(string winnerText)
    {
        _winnerText.text = winnerText;
    }

    public void ExitGame()
    {
        Debug.Log("YOU QUIT THE GAME");
        Application.Quit();
    }

}
