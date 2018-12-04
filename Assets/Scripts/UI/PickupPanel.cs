using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupPanel : MonoBehaviour {

	private Image _spriteRenderer;

	private void Start()
	{
		_spriteRenderer = GameObject.FindWithTag("SinglePickupIcon").GetComponent<Image>();
	}

	// Update is called once per frame
	private void Update()
	{
		var player = GameObject.FindWithTag("Player");
		if (!player) return;
		
		var triggerEffect = player.GetComponentInChildren<TriggerEffect>();
		var weaponPreview = triggerEffect.PreviewSprite;
		var weaponColor = triggerEffect.PreviewColor;

		_spriteRenderer.sprite = weaponPreview;
		_spriteRenderer.color = weaponColor;
	}
}
