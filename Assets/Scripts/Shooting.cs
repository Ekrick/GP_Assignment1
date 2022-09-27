using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    [SerializeField] private WeaponSwap _weaponSwap;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _direction;
    [SerializeField] private int _layerMask;

    [Header("Cannon")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] [Range(10f, 50f)] private float _force;

    [Header("Laser Gun")]
    [SerializeField] private float _laserDamage;
    [SerializeField] private float _laserRange;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _animationDelay;
    private float _delayTimer = 0;
    private bool _animationCheck = true;

    [Header("Shove")]
    [SerializeField] private float _shoveDamage;
    [SerializeField] private float _shoveRadius;
    [SerializeField] private float _shoveRange;

    public void Awake()
    {
        _weaponSwap = GetComponent<WeaponSwap>();
        _lineRenderer = GetComponent<LineRenderer>();
    }
    private void Start()
    {
        this._layerMask = LayerMask.GetMask("Character");
    }
    private void FixedUpdate()
    {
        if (!_animationCheck)
        {
            _delayTimer += Time.deltaTime;
            if (_delayTimer >= _animationDelay)
            {
                _lineRenderer.SetPosition(0, Vector3.zero);
                _lineRenderer.SetPosition(1, Vector3.zero);
                _animationCheck = !_animationCheck;
                _delayTimer = 0;
            }
        }
    }
    public void Shoot()
    {
        if (_weaponSwap.GetActiveIndex() == 0)
        {
            Debug.Log("Fire!");
            CannonFire();

        }
        if (_weaponSwap.GetActiveIndex() == 1)
        {
            Debug.Log("Pew Pew");
            LaserGunFire();
        }
        if (_weaponSwap.GetActiveIndex() == 2)
        {
            Debug.Log("I pushed you!");
            ShoveAttack();
        }
    }

    private void CannonFire()
    {
        var bullet = Instantiate<Rigidbody>(_rb, _spawnPoint.position, _direction.rotation);
        bullet.AddForce(_direction.forward * _force, ForceMode.Impulse);
    }
    private void LaserGunFire()
    {
        LaserVisual();
        RaycastHit hit;
        if (Physics.Raycast(_spawnPoint.position, _direction.forward, out hit, _laserRange, _layerMask))
        {
            //if(hit.transform.gameObject.layer == 7)
            //{
                Debug.Log("Player Hit!");
                hit.transform.GetComponent<CharacterStats>().TakeDamage(_laserDamage);
            //}
        }
    }
    private void ShoveAttack()
    {
        RaycastHit hit;
        if (Physics.SphereCast(_direction.position, _shoveRadius, _direction.forward, out hit, _shoveRange, _layerMask,QueryTriggerInteraction.Ignore))
        {
            //if (hit.transform.gameObject.layer == 7)
            //{
                Debug.Log(hit);
                hit.transform.GetComponent<CharacterStats>().TakeDamage(_shoveDamage);
            //}
        }
    }
    private void LaserVisual()
    {
        if (_animationCheck)
        {
            Vector3 start = _spawnPoint.position;
            Vector3 end = _spawnPoint.forward * _laserRange; ;
            _lineRenderer.SetPosition(0, start);
            _lineRenderer.SetPosition(1, end);
            _animationCheck = false;
        }

    }
}
