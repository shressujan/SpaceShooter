using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fighterShipControls : MonoBehaviour {
	
	public GameObject Bullet;
	public GameObject shoot;
	public GameObject ExplosionGO;
	public GameObject GameManagerGO;

	public Text TextLives;

	const int MaxLives = 3;

	int lives;

	public float speed;

	public void Init()
	{
		lives = MaxLives;
		TextLives.text = lives.ToString();
		//Reset the Players position to center
		transform.position =  new Vector2(0,0);
		gameObject.SetActive (true);
	}

	// Use this for initialization
	void Start()
	{
		speed = 6f;
	}

	// Update is called once per frame
	void Update()
	{

		if(Input.GetKeyDown("space"))
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
			var b = (GameObject) Instantiate (Bullet);
			b.transform.position = shoot.transform.position;
		}
		float x = Input.GetAxisRaw("Horizontal"); //the value will be -1, 0 , 1 for left, no input, or right
		float y = Input.GetAxisRaw("Vertical");

		Vector2 direction = new Vector2(x, y).normalized;

		move(direction);
	}

	//This will destroy  gameObjects  if the enemy bullets hits the gameobject

	void OnTriggerEnter2D(Collider2D other)
	{
		// If the player collided with a bullet or enemy collided with the player
		if (other.gameObject.CompareTag("EnemyBullet") || other.gameObject.CompareTag("Target"))
		{
			PlayExplosionAnimation ();
			lives--;
			TextLives.text = lives.ToString();
			if (lives == 0) {
				GameManagerGO.GetComponent<GameManager> ().SetGameManagerState (GameManager.GameManagerState.GameOver);
				gameObject.SetActive (false);
			}
			Destroy(other.gameObject);
		}
			
	}
	void PlayExplosionAnimation()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionGO);
		explosion.transform.position = transform.position;
		AudioSource audio = explosion.GetComponent<AudioSource>();
		audio.Play();
	}

	void move(Vector2 direction)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		max.x = max.x - 0.225f;
		min.x = min.x + 0.225f;

		max.y = max.y - 0.285f;
		min.y = min.y + 0.285f;

		Vector2 pos = transform.position;

		pos += direction * speed * Time.deltaTime;

		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);

		transform.position = pos;
	}

}

