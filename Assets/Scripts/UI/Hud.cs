using System;
using Combat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Hud : MonoBehaviour
    {
        // UI Objects
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Slider _shieldSlider;
        [SerializeField] private Slider _energySlider;
        [SerializeField] private TextMeshProUGUI _scoreCounterValue;

        // player state
        private Destructible _playerDestruct;
        private PlayerWeapon _playerWeapon;
        private ScoreCounter _playerScore;

        // Update is called once per frame
        void Update()
        {
            if (!HasContext())
            {
                _healthSlider.value = 0;
                _shieldSlider.value = 0;
                _energySlider.value = 0;

                return;
            }

            _healthSlider.value = _playerDestruct.CurrentArmor;
            _shieldSlider.value = _playerDestruct.CurrentShield;
            _energySlider.value = _playerWeapon.CurrentEnergy;
            _scoreCounterValue.text = _playerScore.Score.ToString();
        }

        private bool HasContext()
        {
            if (null != _playerDestruct && null != _playerWeapon && null != _playerScore) return true;

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
            var player = GameObject.FindWithTag("Player");

            _playerDestruct = player.GetComponent<Destructible>();
            _playerWeapon = player.GetComponentInChildren<PlayerWeapon>();
            _playerScore = player.GetComponent<ScoreCounter>();

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