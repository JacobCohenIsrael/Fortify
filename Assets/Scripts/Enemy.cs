﻿using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float MovementSpeed = 1.0f;

	public float AttackRadius = 1.0f;

	public bool IsMoving = true;

	public int AttackDamage = 5;
	
	public Slider EnemyHealthSlider;

	public float AttackSpeed = 1.0f;

	private bool _isAttacking = false;

	private float _nextFireTime;

	private GameObject _target;
	
	private void Start()
	{
		CapsuleCollider collider = GetComponent<CapsuleCollider>();
		collider.radius = AttackRadius;
		_nextFireTime = 0.0f;
	}
	
	private void Update ()
	{
		if (IsMoving)
		{
			var newPosition = new Vector3(transform.position.x + MovementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
			transform.position = newPosition;
		}

		if (null != _target)
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
		//EnemyHealthSlider.value = GetComponent<Attackable>().HitPoints;
	}
	
	private void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			if (contact.otherCollider.gameObject.tag.Equals("Base"))
			{
				IsMoving = false;
				_target = contact.otherCollider.gameObject;
			}
		}
	}

}
