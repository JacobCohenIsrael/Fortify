using UnityEngine;

public class EnemyHealth : Attackable 
{
	protected override void Die()
	{
		var animator = GetComponent<Animator>();
		if (null != animator)
		{
			animator.SetTrigger("isDead");
		}
	}
}