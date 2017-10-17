﻿using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float MovementSpeed = 1.0f;

	public float AttackRadius = 1.0f;

	public bool IsMoving = true;

	public int AttackDamage = 5;
	
	public Slider EnemyHealthSlider;

	public float AttackSpeed = 1.0f;

	public float HitRadius = 2.0f;

	public SphereCollider HitCollider;

	private bool _isAttacking = false;

	private float _nextFireTime;

	private GameObject _target;
	
	private void Start()
	{
		_nextFireTime = 0.0f;
		HitCollider.radius = HitRadius;
	}
	
	private void Update ()
	{
		if (IsMoving)
		{
			transform.Translate(Vector3.right * Time.deltaTime * MovementSpeed, Camera.main.transform);
		}

		if (null == _target)
		{
			CheckWhatsInfront();
		}
		else
		{
			if (Time.time > _nextFireTime)
			{
				Attackable attackableBase = _target.GetComponent<Attackable>();
				if (null != attackableBase)
				{
					attackableBase.TakeDamage(AttackDamage);
					_nextFireTime = Time.time + AttackSpeed;
				}
			}
		}
		EnemyHealthSlider.value = GetComponent<Attackable>().HitPoints;
	}
	
//	private void OnCollisionEnter(Collision collision)
//	{
//		foreach (ContactPoint contact in collision.contacts)
//		{
//			if (contact.otherCollider.gameObject.tag.Equals("Base"))
//			{
//
//			}
//		}
//	}

	private void CheckWhatsInfront()
	{
		RaycastHit objectHit;
		Vector3 fwd = gameObject.transform.TransformDirection(Vector3.right);
		Debug.DrawRay(gameObject.transform.position, fwd * AttackRadius, Color.green);
		if (Physics.Raycast(gameObject.transform.position, fwd, out objectHit, AttackRadius))
		{
			//do something if hit object ie
			if (objectHit.collider.tag=="Base")
			{
				IsMoving = false;
				_target = objectHit.collider.gameObject;
			}
		}
	}
}
