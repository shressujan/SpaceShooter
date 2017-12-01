//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnner : MonoBehaviour {

	public GameObject enemy01;
	public GameObject enemy02;
	public GameObject enemy03;
	public GameObject enemyTheBoss;
	public GameObject rock;
	public GameObject asteroid;
	public GameObject GameScores;



	public float maxSpawnRateInSeconds = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Function to spawn enemy
	void SpawnEnemy1()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		//This will spawn enemies in random position 

		GameObject enemy1 = (GameObject)Instantiate(enemy01);
		enemy1.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

		ScheduleNextEnemySpawn();
	}

	//Function to spawn enemy
	void SpawnEnemy2()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		GameObject enemy2 = (GameObject)Instantiate(enemy02);
		enemy2.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        ScheduleNextEnemySpawn();
	}

	//Function to spawn enemy
	void SpawnEnemy3()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		GameObject enemy3 = (GameObject)Instantiate(enemy03);
		enemy3.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    	ScheduleNextEnemySpawn();
	}

	//Function to spawn enemy
	public void SpawnEnemyBoss()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		GameObject enemyBoss = (GameObject)Instantiate(enemyTheBoss);
		enemyBoss.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        
	}

	//Function to spawn enemy
	void SpawnEnemyrock()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		GameObject rock1 = (GameObject)Instantiate(rock);
		rock1.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        ScheduleNextEnemySpawn();
	}

	//Function to spawn enemy
	void SpawnEnemyAsteroid()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		GameObject asteroid1 = (GameObject)Instantiate(asteroid);
		asteroid1.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        ScheduleNextEnemySpawn();
	}
	
	void ScheduleNextEnemySpawn()
	{

		float spawnInSeconds;

		if (maxSpawnRateInSeconds > 1f)
		{
			spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
		}
		else
		{
			spawnInSeconds = 1f;
		}
		int score = GameScores.GetComponent<ScoresScript> ().Scores;
		//Calls the boss enemy when the player scores 2000
		if (score > 600	) {
			Invoke ("SpawnEnemyBoss", maxSpawnRateInSeconds);
		} else {
			RandomEnemyCall (spawnInSeconds);
		}
	}

	void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;
		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke ("IncreaseSpawnRate");
	}

	public void ScheduleEnemySpawnner()
	{
		maxSpawnRateInSeconds = 5f;
		Invoke("ScheduleNextEnemySpawn", maxSpawnRateInSeconds);
		InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);

	}
	public void UnScheduleEnemySpawnner()
	{
		CancelInvoke ("ScheduleNextEnemySpawn");
		CancelInvoke ("SpawnEnemy1");
		CancelInvoke ("SpawnEnemy2");
		CancelInvoke ("SpawnEnemy3");
		CancelInvoke ("SpawnEnemyrock");
		CancelInvoke ("SpawnEnemyAsteroid");
		CancelInvoke ("IncreaseSpawnRate");
		CancelInvoke ("SpawnEnemyBoss");
	}

	void RandomEnemyCall(float spawnInSeconds)
	{
		int num = Random.Range(1, 6);
		switch (num)
		{
			case 1:
				{
					Invoke("SpawnEnemy1", spawnInSeconds);
					break;
				}
			case 2:
				{

					Invoke("SpawnEnemy2", spawnInSeconds);
					break;
				}
			case 3:
				{

					Invoke("SpawnEnemy3", spawnInSeconds);
					break;
				}
			case 4:
				{

                	Invoke("SpawnEnemyrock", spawnInSeconds);
					break;
				}
			case 5:
				{

                    Invoke("SpawnEnemyAsteroid", spawnInSeconds);
					break;
				}
			default:
				{
					break;
				}
		}
	}
		
}
