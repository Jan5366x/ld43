using Combat;
using UnityEngine;

namespace UI
{
    public class WeaponPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _singleShotIcon;

        private string _activeWeapon;

        // Update is called once per frame
        private void Update()
        {
            var currentWeapon = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerWeapon>().Projectile.name;

            if (currentWeapon == _activeWeapon) return;

            switch (currentWeapon)
            {
                case "PlayerShotSimpleA":
                    _singleShotIcon.SetActive(true);
                    break;
                default:
                    Debug.LogError(string.Format("Unknown Weapon \"{0}\"", currentWeapon));
                    break;
            }

            _activeWeapon = currentWeapon;
        }
    }
}