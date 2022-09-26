using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    [SerializeField] private WeaponSwap _weaponSwap;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _direction;

    [Header("Cannon")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] [Range(10f, 50f)] private float _force;

    [Header("Laser Gun")]
    [SerializeField] private float _laserDamage;

    [Header("Shove")]
    [SerializeField] private float _shoveDamage;

    public void Awake()
    {
        _weaponSwap = GetComponent<WeaponSwap>();
    }
    public void Shoot()
    {
        if (_weaponSwap.GetActiveIndex() == 0)
        {
            Debug.Log("Fire!");
            var bullet = Instantiate<Rigidbody>(_rb, _spawnPoint.position, _direction.rotation);
            bullet.AddForce(_direction.forward * _force, ForceMode.Impulse);
        }
        if (_weaponSwap.GetActiveIndex() == 1)
        {
            Debug.Log("Pew Pew");
        }
        if (_weaponSwap.GetActiveIndex() == 2)
        {
            Debug.Log("I pushed you!");
        }
    }
}
