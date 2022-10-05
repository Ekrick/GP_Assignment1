using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoPanelScript : MonoBehaviour
{
    [SerializeField] private CharacterStats _characterStats;
    [SerializeField] private WeaponSwap _weaponSwap;
    [SerializeField] private TextMeshProUGUI _currentHealth;
    [SerializeField] private TextMeshProUGUI _currentWeapon;

    private void Update()
    {
        CheckPlayer();
        _currentHealth.text = Health();
        _currentWeapon.text = Weapon();
    }

    private string Health()
    {
        if (_characterStats != null)
        {
            return _characterStats.GetHealth().ToString();
        }
        else
        {
            Debug.Log("Error, missing swap-script");
            return null;
        }

    }

    private string Weapon()
    {
        if (_weaponSwap != null)
        {
            return _weaponSwap.GetActiveWeapon().GetWeaponType();
        }
        else
        {
            Debug.Log("Error, missing swap-script");
            return null;
        }

    }

    private void CheckPlayer()
    {
        if (GameManager.Instance.GetActivePlayer() != null)
        {
            _characterStats = GameManager.Instance.GetActivePlayer();
            _weaponSwap = _characterStats.gameObject.GetComponent<WeaponSwap>();
        }
    }
}
