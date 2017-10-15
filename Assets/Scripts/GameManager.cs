﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Transform[] EnemySpawnPoints;

	public GameObject EnemyPrefab;

	private void Start()
	{
		InvokeRepeating("spawnEnemy", 0.5f, 2.5f);
	}

	private void spawnEnemy()
	{
		foreach (var enemySpawnPoint in EnemySpawnPoints)
		{
			Instantiate(EnemyPrefab, enemySpawnPoint);
		}
	}
}
