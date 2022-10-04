using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private string _playerName;
    [SerializeField] private Transform _camLook;
    [SerializeField] private CinemachineFreeLook _followCam;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    public bool _myTurn;

    private void Start()
    {
        _currentHealth = _maxHealth;

        if (_myTurn)
        {
            _input.enabled = true;
            _followCam.enabled = true;
        }
        else
        {
            _input.enabled = false;
            _followCam.enabled = false;
        }
    }
    public string GetName()
    {
        return _playerName;
    }
    public PlayerInput GetInput()
    {
        return _input;
    }

    public CinemachineFreeLook GetCamera()
    {
        return _followCam;
    }

    public float GetHealth()
    {
        return _currentHealth;
    }
    public float GetMaxHealth()
    {
        return _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            GameManager.Instance.SwitchPlayer();
            this.gameObject.SetActive(false);
        }
    }

    public void MaxHeal()
    {
        _currentHealth = _maxHealth;
    }

}
