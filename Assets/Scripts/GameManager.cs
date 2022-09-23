using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [Header("Players")]
    [SerializeField] private CharacterStats _player1;
    [SerializeField] private CharacterStats _player2;

    [Header("UI")]
    [SerializeField] private Canvas _endGameScreen;
    [SerializeField] private GameOverText _endText;

    [SerializeField] private float _bufferTime;
    private float _timePassed = 0;
    private bool _changingPlayer;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
        _changingPlayer = false;
        _player1._myTurn = true;
        _player2._myTurn = false;
    }
    private void Update()
    {
        if (_player1.enabled && !_player2.enabled)
        {
            _endGameScreen.enabled = true;
            _endText.winnerText.text = GameOver(_player1);
        }
        else if (!_player1.enabled && _player2.enabled)
        {
            _endGameScreen.enabled = true;
            _endText.winnerText.text = GameOver(_player2);
        }

        if (_changingPlayer)
        {
            _timePassed += Time.deltaTime;
            if (_timePassed > _bufferTime)
            {
                _changingPlayer = false;
                _timePassed = 0;
                ChangeActive();
            }
        }
    }

    public static GameManager GetInstance()
    {
        return Instance;
    }   
    public void SwitchPlayer()
    {
        CamSwap();
        _changingPlayer = true;
    }
    private void ChangeActive()
    {
        _player1._myTurn = !_player1._myTurn;
        _player2._myTurn = !_player2._myTurn;
        _player1.GetInput().enabled = _player1._myTurn;
        _player2.GetInput().enabled = _player2._myTurn;
    }
    private void CamSwap()
    {
        if (_player1.GetCamera().enabled)
        {
            _player1.GetCamera().enabled = false;
            _player2.GetCamera().enabled = true;
        }
        else if (_player2.GetCamera().enabled)
        {
            _player1.GetCamera().enabled = true;
            _player2.GetCamera().enabled = false;
        }
        else
        {
            Debug.Log("Error");
        }
    }
    private string GameOver(CharacterStats winner)
    {
        string victoryText;
        victoryText = winner.GetName() + " wins!";
        return victoryText;
    }

}
