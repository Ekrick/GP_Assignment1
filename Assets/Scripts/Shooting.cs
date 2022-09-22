using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _direction;
    [SerializeField] [Range(10f, 50f)] private float _force;
    public void Shoot()
    {
        Debug.Log("Fire!");
        var bullet = Instantiate<Rigidbody>(_rb, _spawnPoint.position, _direction.rotation);
        bullet.AddForce(_direction.forward * _force, ForceMode.Impulse);
    }
}
