using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weaponList = new List<Weapon>();
    private int _equippedIndex = 0;
    private Weapon _activeWeapon;
    public class Weapon
    {
        private string _weaponType;
        private bool _equipped;

        public Weapon(string s, bool b)
        {
            _weaponType = s;
            _equipped = b;
        }

        public string GetWeaponType()
        {
            return _weaponType;
        }
        public bool GetWeaponEquipped()
        {
            return _equipped;
        }
        public void ChangeEquipped()
        {
            _equipped = !_equipped;
        }
    }

    Weapon weapon1 = new Weapon("Cannon", true);
    Weapon weapon2 = new Weapon("Laser Gun", false);
    Weapon weapon3 = new Weapon("Health Pack", false);

    private void Start()
    {
        _activeWeapon = weapon1;
        _weaponList.Add(weapon1);
        _weaponList.Add(weapon2);
        _weaponList.Add(weapon3);
    }

    public Weapon GetActiveWeapon()
    {
        return _activeWeapon;
    }
    public int GetActiveIndex()
    {
        return _equippedIndex;
    }

    public void SwapWeapon()
    {
        _weaponList[_equippedIndex].ChangeEquipped();
        _equippedIndex += 1;
        if (_equippedIndex >= _weaponList.Count)
        {
            _equippedIndex = 0;
        }
        _weaponList[_equippedIndex].ChangeEquipped();
        _activeWeapon = _weaponList[_equippedIndex];
        Debug.Log(_activeWeapon.GetWeaponType());
    }

    public void RemoveWeapon(int index)
    {
        _weaponList.RemoveAt(index);
    }
}

