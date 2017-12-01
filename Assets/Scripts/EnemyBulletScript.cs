using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {

	public float speed;
	Vector2 _direction; //the direction of the bullet
	bool isReady;

	void Awake()
	{
		speed = 5f;
		isReady = false;
	}

	//Function to set the bullets direction
	public void SetDirection(Vector2 direction)
	{
		_direction = direction.normalized;
		isReady = true;
	}
	// Use this for initialization
	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
		if (isReady)
		{
			Vector2 position = transform.position;
			position +=(_direction * speed* Time.deltaTime);
			transform.position = position;

			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
			//Checks if the bullet has reached the edges of the game window and if it does, destroys the bullet
			if (transform.position.y < min.y || transform.position.x < min.x
			    || transform.position.y > max.y || transform.position.x > max.x)
			{
				Destroy(gameObject);
			}
		}
	}
}
