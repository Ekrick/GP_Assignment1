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
    [SerializeField] private GameObject _endGameScreen;
    [SerializeField] private InfoPanelScript _gameUI;
    [SerializeField] private GameOverScreen _endText;
    public static int _winnerCheck;

    [Header("Character Switching")]
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

        _player1._myTurn = true;
        _player2._myTurn = false;
    }
    private void Start()
    {
        _changingPlayer = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void Update()
    {
        EndCheck();

        if (_changingPlayer)
        {
            SwitchDelay();
        }
    }

 
    public CharacterStats GetActivePlayer()
    {
        if (_player1._myTurn)
        {
            return _player1;
        }
        else if (_player2._myTurn)
        {
            return _player2;
        }
        else
        {
            return null;
        }
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
    public void SwitchPlayer()
    {
        if (_player1.enabled && _player2.enabled)
        {
            CamSwap();
            _changingPlayer = true;
        }
    }
    private void SwitchDelay()
    {
        _timePassed += Time.deltaTime;
        if (_timePassed > _bufferTime)
        {
            _changingPlayer = false;
            _timePassed = 0;
            ChangeActive();
        }
    }
    private void EndCheck()
    {
        if (_player1.gameObject.activeSelf && !_player2.gameObject.activeSelf)
        {
            _winnerCheck = 1;
            GameOver(_player1);
        }
        else if (!_player1.gameObject.activeSelf && _player2.gameObject.activeSelf)
        {
            _winnerCheck = 2;
            GameOver(_player2);

        }
    }
    private void GameOver(CharacterStats winner)
    {
        _player1.GetInput().enabled = false;
        _player2.GetInput().enabled = false;
        _gameUI.gameObject.SetActive(false);
        Cursor.visible = true;
        string victoryText;
        victoryText = winner.GetName() + " wins!";
        _endGameScreen.SetActive(true);
        _endText.WinnerText(victoryText);
    }


}
