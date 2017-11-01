﻿﻿﻿using System.Collections;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
	public LineRenderer LineOfSight;

	public Light GunLight;
 
	public Transform ShotOrigin;

	public float FireRate;

	public int GunDamage;

	public float HitForce;

	public GameObject HitEffect;

	private WaitForSeconds shotDuration = new WaitForSeconds(.05f);

	private float _nextFire;

	private void Start()
	{
		LineOfSight = GetComponent<LineRenderer>();
	}
	
	public void Update()
	{
		if (Input.GetButtonDown("Fire1") && Time.time > _nextFire)
		{
			_nextFire = Time.time + FireRate;

			StartCoroutine(shotEffect());
			
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			LineOfSight.SetPosition(0, ShotOrigin.position);
			
			if (Physics.Raycast(ray, out hit))
			{
				Attackable attackable = hit.collider.GetComponent<Attackable>();

				if (null != attackable && hit.collider.CompareTag("Enemy"))
				{
					attackable.TakeDamage(GunDamage);
				}
				else
				{
					Instantiate(HitEffect, hit.point + new Vector3(0, 0.1f, 0), Quaternion.identity);
				}

				if (null != hit.rigidbody)
				{
					hit.rigidbody.AddForce(new Vector3(-hit.normal.x, 0, 0) * HitForce);
				}
				LineOfSight.SetPosition(1, hit.point);
				
			}

		}
	}

	private IEnumerator shotEffect()
	{
		LineOfSight.enabled = true;
		GunLight.enabled = true;
		yield return shotDuration;
		LineOfSight.enabled = false;
		GunLight.enabled = false;
	}
     
}