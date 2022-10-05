using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    private Vector3 _moveVector;

    [Header("Damage Conditions")]
    [SerializeField] private float _damage;
    [SerializeField] private float _damageVelocity;
    private bool _hurtful = true;

    [Header("Despawn Conditions")]
    [SerializeField] private float _minMove;
    [SerializeField] private float _stopCheck = 0f;
    private bool _grounded = false;
    private float _timer = 0;

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody>();  
    }
    private void Update()
    {
        _moveVector = this._rb.velocity;
        if (_grounded)
        {
            DestroyCheck();
        }
    }

    private void DestroyCheck()
    {
        _timer += Time.deltaTime;
        if (_timer > _stopCheck)
        {
            if (_moveVector.magnitude <= _minMove)
            {
                _timer = 0f;
                Destroy(this.gameObject);
            }
            else
            {
                _timer = 0f;
                _grounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision hit)
    {
        Debug.Log("Collision!");
        if (hit.gameObject.layer == 7 && _moveVector.magnitude > _damageVelocity)
        {
            Debug.Log("Player Hit!");
            CharacterStats stats = hit.gameObject.GetComponent<CharacterStats>();
            if (stats != null && _hurtful)
            {
                stats.TakeDamage(_damage);
                _hurtful = false;
            }
        }
    }
    private void OnCollisionStay(Collision hit)
    {
        if (hit.gameObject.layer == 6)
        {
                _grounded = true;
        }
    }

}
