using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy01Script : MonoBehaviour {

	public float speed;
	public GameObject ExplosionGO;
	public GameObject TextScoresGO;
	public GameObject GameManagerGO;

	//Counts the number of hits taken by the enemies.
	private int hits;
	private int maxhits;
	private int num;
	private int randNum;

	// Use this for initialization
	void Start()
	{
		hits = 0;
		maxhits = Random.Range(10,20);
		speed = 2f;
		num = Random.Range(1, 6);
		TextScoresGO = GameObject.FindGameObjectWithTag ("GameScores");
		GameManagerGO = GameObject.FindGameObjectWithTag ("GameManager");
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 position = transform.position;
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		if (gameObject.name.Equals("enemyTheBoss(Clone)")) {
			print (gameObject.name);
			randNum = Random.Range(1, 3);
			switch (randNum) {
			case 1:
				{
					if (transform.position.x > min.x) {
						position = new Vector2 (position.x - 20f * Time.deltaTime, position.y - 0.5f * Time.deltaTime);
					}
					break;
				}
			case 2:
				{
					if (transform.position.x < max.x) {
						position = new Vector2 (position.x + 20f * Time.deltaTime, position.y - 0.5f * Time.deltaTime);
					}
					break;
				}
			default:
				{
					break;
				}
			}
		} else {
			position = new Vector2(position.x, position.y - speed * Time.deltaTime);
		}
		transform.position = position;


		
//		if (transform.position.y < min.y || GameManagerGO.GetComponent<GameManager>().GetGameManagerState == GameManager.GameManagerState.Opening)
//		{
//			Destroy(gameObject);
//		}
	}
	//This will destroy gameObjects  if the players bullets hits the gameobject

	void OnTriggerEnter2D(Collider2D other)
	{
		// If the enemy collided with a bullet
		if (other.gameObject.CompareTag("PlayerBullet"))
		{
			PlayExplosionAnimation ();
			hits++;
			if (gameObject.name.Equals ("enemyTheBoss(Clone)")) {
				num = maxhits;
			}
			if (hits == num) {
				Destroy (gameObject);
				//Add 100 points to every hit
				TextScoresGO.GetComponent<ScoresScript>().Scores += 100;
				if (num == maxhits) {
					GameManagerGO.GetComponent<GameManager> ().SetGameManagerState (GameManager.GameManagerState.GameWin);
				}
			}
            Destroy(other.gameObject);
		}
	}

	//To destroy targets after the player has died
	public void RefreshScreen()
	{
		Destroy (gameObject);
	}
	void PlayExplosionAnimation()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionGO);
		explosion.transform.position = transform.position;
		AudioSource audio = explosion.GetComponent<AudioSource>();
		audio.Play();
	}

}
