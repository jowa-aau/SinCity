﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBuildings : MonoBehaviour
{
	[SerializeField] private Sprite destroyedSprite;
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Skill")) {
			SpriteRenderer renderer = GetComponent<SpriteRenderer>();
			renderer.sprite = destroyedSprite;
		}
	}
}