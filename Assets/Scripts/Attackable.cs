﻿using UnityEngine;

public class Attackable : MonoBehaviour
{
	public int HitPoints = 100;
	
	public void TakeDamage(int damageTaken)
	{
		HitPoints -= damageTaken;

		if (HitPoints < 1)
		{
			Destroy(gameObject);
		}
	}
}
