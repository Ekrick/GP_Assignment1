using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    public Text winnerText;

    public GameOverText(Text winnerText)
    {
        this.winnerText = winnerText;
    }
}
