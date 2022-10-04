using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winnerText;
    public static int winnerCheck;

    public void WinnerText(string winnerText)
    {
        _winnerText.text = winnerText;
    }

    public void GoToEndScene()
    {
        SceneManager.LoadScene(2);
    }


}
