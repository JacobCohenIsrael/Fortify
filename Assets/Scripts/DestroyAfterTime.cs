using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

	public float DestroyDelay;
	
	void Start () 
	{
		Destroy(gameObject, DestroyDelay);	
	}
}
