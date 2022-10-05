using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private CharacterStats _characterStats;
    [SerializeField] private Image _healthBar;
    [SerializeField] private TextMeshProUGUI _characterName;
    [SerializeField] private Camera _mainCam;

    private void Awake()
    {
        _characterStats = GetComponentInParent<CharacterStats>();
        _mainCam = Camera.main;
    }
    private void Start()
    {
        _characterName.text = CharacterName();
    }
    private void Update()
    {
        _healthBar.fillAmount = HealthPercentage();
        this.transform.forward = _mainCam.transform.forward;
    }


    private string CharacterName()
    {
        if (_characterStats != null)
        {
            return _characterStats.GetName();
        }
        else
        {
            Debug.Log("Error, missing stats");
            return null;
        }

    }

    private float HealthPercentage()
    {
        if (_characterStats != null)
        {
            float per;
            per = _characterStats.GetHealth() / _characterStats.GetMaxHealth();
            return per;
        }
        else
        {
            Debug.Log("Error, missing stats");
            return 0;
        }
    }
}
