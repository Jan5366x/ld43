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
            var player = GameObject.FindWithTag("Player");
            if(!player) return;
            
            var playerWeapon = player.GetComponentInChildren<PlayerWeapon>();
            var weaponPreview = playerWeapon.WeaponPreview;
            var weaponColor = playerWeapon.WeaponColor;

            _spriteRenderer.sprite = weaponPreview;
            _spriteRenderer.color = weaponColor;
        }
    }
}