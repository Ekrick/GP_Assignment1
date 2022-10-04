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
        return _characterStats.GetName();
    }

    private float HealthPercentage()
    {
        float per;
        per = _characterStats.GetHealth() / _characterStats.GetMaxHealth();
        return per;
    }
}
