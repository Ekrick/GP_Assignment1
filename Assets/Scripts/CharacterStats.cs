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
    [SerializeField] private float _health;
    public bool _myTurn;

    private void Start()
    {
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
        return _health;
    }
    
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health < 0)
        {
             this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }

}
