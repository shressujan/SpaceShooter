using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {

	public GameObject EnemyBullet;
	// Use this for initialization
	void Start () {
		GameObject enemy = GameObject.Find("enemyTheBoss(Clone)");
		if (enemy == null) {
			Invoke("FireEnemyBullet", 1f);
		} else {
			InvokeRepeating("FireEnemyBulletBoss", 0f, 1.5f);
		}

        
	}

	//Cancels the invoke
	public void CancelFire()
	{

		CancelInvoke("FireEnemyBulletBoss");
	}
	// Update is called once per frame
	void Update () {
		
	}

	void FireEnemyBullet()
	{
		GameObject playership = GameObject.Find("fighterShip");
		if(playership != null)
		{
			GameObject bullet = (GameObject)Instantiate(EnemyBullet);
			bullet.transform.position = transform.position;

			Vector2 direction = playership.transform.position - bullet.transform.position;

			bullet.GetComponent<EnemyBulletScript>().SetDirection(direction);
		}
	}

	void FireEnemyBulletBoss()
	{
		GameObject playership = GameObject.Find("fighterShip");
		if(playership != null)
		{
			GameObject bullet = (GameObject)Instantiate(EnemyBullet);
			bullet.transform.position = transform.position;

			Vector2 direction = playership.transform.position - bullet.transform.position;

			bullet.GetComponent<EnemyBulletScript>().SetDirection(direction);
		}
	}
}
