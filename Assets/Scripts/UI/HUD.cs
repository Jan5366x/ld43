using System;
using Combat;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private Slider _healthSlider;
    private Slider _shieldSlider;
    private GameObject _player;
    private Destructible _playerDestruct;
    private Slider _energySlider;
    private PlayerWeapon _playerWeapon;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!InitPlayer()) return;

        _healthSlider.value = _playerDestruct.CurrentArmor;
        _shieldSlider.value = _playerDestruct.CurrentShield;
        _energySlider.value = _playerWeapon.CurrentEnergy;
    }

    private bool InitPlayer()
    {
        if (null == _player)
        {
            _healthSlider = GameObject.FindWithTag("HealthBar").GetComponent<Slider>();
            _shieldSlider = GameObject.FindWithTag("ShieldBar").GetComponent<Slider>();
            _energySlider = GameObject.FindWithTag("EnergyBar").GetComponent<Slider>();

            _player = GameObject.FindWithTag("Player");

            if (null == _player) return false;

            _playerDestruct = _player.GetComponent<Destructible>();
            _playerWeapon = _player.GetComponentInChildren<PlayerWeapon>();

            //init sliders
            _healthSlider.maxValue = _playerDestruct.MaxArmor;
            _healthSlider.value = _playerDestruct.CurrentArmor;

            _shieldSlider.maxValue = _playerDestruct.MaxShield;
            _shieldSlider.value = _playerDestruct.CurrentShield;

            _energySlider.maxValue = _playerWeapon.MaxEnergy;
            _energySlider.value = _playerWeapon.CurrentEnergy;
        }

        return null != _player;
    }
}
