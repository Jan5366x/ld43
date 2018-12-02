using System;
using Combat;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Hud : MonoBehaviour
    {
        // UI Objects
        private Slider _healthSlider;
        private Slider _shieldSlider;
        private Slider _energySlider;

        // player state
        private Destructible _playerDestruct;
        private PlayerWeapon _playerWeapon;

        // Update is called once per frame
        void Update()
        {
            if (!HasContext()) return;

            _healthSlider.value = _playerDestruct.CurrentArmor;
            _shieldSlider.value = _playerDestruct.CurrentShield;
            _energySlider.value = _playerWeapon.CurrentEnergy;
        }

        private bool HasContext()
        {
            if (null != _playerDestruct && null != _playerWeapon) return true;
            
            try
            {
                InitContext();
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e);
                return false;
            }

            return true;
        }

        private void InitContext()
        {
            _healthSlider = GameObject.FindWithTag("HealthBar").GetComponent<Slider>();
            _shieldSlider = GameObject.FindWithTag("ShieldBar").GetComponent<Slider>();
            _energySlider = GameObject.FindWithTag("EnergyBar").GetComponent<Slider>();

            var player = GameObject.FindWithTag("Player");

            _playerDestruct = player.GetComponent<Destructible>();
            _playerWeapon = player.GetComponentInChildren<PlayerWeapon>();

            //init sliders
            _healthSlider.maxValue = _playerDestruct.MaxArmor;
            _healthSlider.value = _playerDestruct.CurrentArmor;

            _shieldSlider.maxValue = _playerDestruct.MaxShield;
            _shieldSlider.value = _playerDestruct.CurrentShield;

            _energySlider.maxValue = _playerWeapon.MaxEnergy;
            _energySlider.value = _playerWeapon.CurrentEnergy;
        }
    }
}