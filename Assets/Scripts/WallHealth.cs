using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : Attackable 
{
	protected override void Die()
	{
		Destroy(gameObject);
	}
}
