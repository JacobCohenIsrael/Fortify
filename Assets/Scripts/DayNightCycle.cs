using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{

	public Vector3 StartRotation;
	public Vector3 EndRotation;
	public float DayLength;

	void Start()
	{
		transform.rotation = Quaternion.Euler(StartRotation);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(EndRotation), Time.deltaTime / DayLength);
	}
}
