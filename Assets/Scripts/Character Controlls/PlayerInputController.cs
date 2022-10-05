using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerInputController : MonoBehaviour
{
    [Header ("Components")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Transform _followCamera;
    [SerializeField] private Shooting _shooting;
    [SerializeField] private CharacterStats _characterStats;
    [SerializeField] private WeaponSwap _weaponSwap;

    [Header("Movement")]
    [SerializeField] [Range(1f, 10f)] private float _moveSpeed;
    private Vector3 _inputVector;

    [Header("Jumping")]
    [SerializeField] [Range(5f, 15f)] private float _jumpForce;
    [SerializeField] [Range(1f, 20f)] private float _gravity;
    private Vector3 _jumpVector;
[Header("Camera")]
    [SerializeField] [Range(0.1f, 0.2f)] private float _turnTime;
    private float _turnSpeed;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _shooting = GetComponent<Shooting>();
        _characterStats = GetComponent<CharacterStats>();
        _input = GetComponent<PlayerInput>();
        _weaponSwap = GetComponent<WeaponSwap>();
        _followCamera = Camera.main.transform;
    }

    private void FixedUpdate()
    {

        if (_inputVector.magnitude >= 0.1f)
        {
            float newAngle = Mathf.Atan2(_inputVector.x, _inputVector.z) * Mathf.Rad2Deg + _followCamera.eulerAngles.y;
            float turnAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, newAngle, ref _turnSpeed, _turnTime);
            transform.rotation = Quaternion.Euler(0f, turnAngle, 0f);

            Vector3 moveVector = Quaternion.Euler(0f, newAngle, 0f) * Vector3.forward;
            _characterController.Move(moveVector.normalized * _moveSpeed * Time.deltaTime);
        }

        if (!_characterController.isGrounded)
        {
            _jumpVector.y -= _gravity * Time.deltaTime;
        }
        _characterController.Move(_jumpVector * Time.deltaTime);

        
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 moveValue = context.ReadValue<Vector2>();
        _inputVector = new Vector3(moveValue.x, 0, moveValue.y);
    }
    public void Look(InputAction.CallbackContext context)
    {
       // _looking = context.ReadValue<Vector2>();

      //  Vector3 direction = new Vector3(_looking.x, 0, _looking.y).normalized;
    }
    public void Fire(InputAction.CallbackContext context)
    {
        if (context.started && CheckActive() && _shooting != null)
        {
           _shooting.Shoot();
           _input.enabled = false;
            GameManager.Instance.SwitchPlayer();
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jumping");
        if (context.started && _characterController.isGrounded)
        {
            _jumpVector.y = _jumpForce;
        }
    }
    public void SwitchWeapon(InputAction.CallbackContext context)
    {
        if (context.performed && _weaponSwap != null)
        {
            _weaponSwap.SwapWeapon();
        }

    }

    private bool CheckActive()
    {
        if (_characterStats._myTurn && _characterStats != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
    
