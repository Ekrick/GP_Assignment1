using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameScene : MonoBehaviour
{
    [SerializeField] private Material _player1;
    [SerializeField] private Material _player2;
    [SerializeField] private GameObject _winner;
    [SerializeField] private GameObject _loser;

    private void Start()
    {
        if (GameManager._winnerCheck == 1)
        {
            _winner.GetComponent<MeshRenderer>().material = _player1;
            _loser.GetComponent<MeshRenderer>().material = _player2;
        }
        if (GameManager._winnerCheck == 2)
        {
            _winner.GetComponent<MeshRenderer>().material = _player2;
            _loser.GetComponent<MeshRenderer>().material = _player1;
        }

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
