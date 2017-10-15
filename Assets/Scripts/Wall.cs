using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{

	public Slider HitpointsSlider;

	private Attackable _attackable;
	
	private void Start()
	{
		_attackable = GetComponent<Attackable>();
	}
	
	private void Update ()
	{
		HitpointsSlider.value = _attackable.HitPoints;
	}
}
