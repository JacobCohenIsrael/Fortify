using UnityEngine;

public abstract class Attackable : MonoBehaviour
{
	public int HitPoints = 100;

	protected bool isDead = false;
	
	public void TakeDamage(int damageTaken)
	{
		HitPoints -= damageTaken;

		if (HitPoints < 1 && !isDead)
		{
			Die();
		}
	}

	protected abstract void Die();
}
