using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Sun : MonoBehaviour
{

	public Transform RotateAroundTransform;

	public float RotateSpeed = 1.0f;
	
	private void Update ()
	{
		_orbitAround();
	}

	private void _orbitAround()
	{
		transform.RotateAround(RotateAroundTransform.position, Vector3.forward, RotateSpeed / Time.deltaTime);
	}
}
