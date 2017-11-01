using UnityEngine;

public class EnemyHealth : Attackable 
{
	protected override void Die()
	{
		var animator = GetComponent<Animator>();
		if (null != animator)
		{
			animator.SetTrigger("isDead");
			isDead = true;
		}
		var enemy = GetComponent<Enemy>();
		if (null != enemy)
		{
			ScoreManager.Score += enemy.ScoreValue;
		}
		Destroy(gameObject, 2.0f);
	}
}