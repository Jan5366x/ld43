using Combat;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WeaponPanel : MonoBehaviour
    {
        private Image _spriteRenderer;

        private void Start()
        {
            _spriteRenderer = GameObject.FindWithTag("SingleShotIcon").GetComponent<Image>();
        }

        // Update is called once per frame
        private void Update()
        {
            var playerWeapon = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerWeapon>();
            var weaponPreview = playerWeapon.WeaponPreview;
            var weaponColor = playerWeapon.WeaponColor;

            _spriteRenderer.sprite = weaponPreview;
            _spriteRenderer.color = weaponColor;
        }
    }
}