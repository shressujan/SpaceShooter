using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetControllerScript : MonoBehaviour {
	public GameObject [] planets;

	Queue <GameObject> availablePlanets =  new Queue<GameObject>();
	// Use this for initialization
	void Start () {
		
		availablePlanets.Enqueue (planets [0]);
		availablePlanets.Enqueue (planets [1]);
		availablePlanets.Enqueue (planets [2]);

		InvokeRepeating ("MovePlanetsDown", 0, 20f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MovePlanetsDown()
	{
		EnqueuePlanets ();	
		if (availablePlanets.Count == 0) {	
			return;
		}
		GameObject aPlanet = availablePlanets.Dequeue ();
		aPlanet.GetComponent<PlanetScript> ().isMoving = true;
	}

	void EnqueuePlanets()
	{
		foreach (GameObject aPlanet in planets) {
			if((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<PlanetScript>().isMoving))
			{
				aPlanet.GetComponent<PlanetScript>().ResetPosition();

				availablePlanets.Enqueue(aPlanet);
			}
		}
	}
}
