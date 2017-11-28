﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
	public Transform[] EnemySpawnPoints;

	public GameObject EnemyPrefab;

	private void Start()
	{
		InvokeRepeating("spawnEnemy", 0.5f, 3.5f);
	}

	private void spawnEnemy()
	{

		var enemySpawnPoint = Random.Range(1, 3);
		Instantiate(EnemyPrefab, EnemySpawnPoints[enemySpawnPoint]);
	}
}
