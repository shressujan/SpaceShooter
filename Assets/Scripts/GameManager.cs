using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject PlayButton;
	public GameObject fighterShip;
	public GameObject enemySpawnner;
	public GameObject GameOver;
	public GameObject TextScoresGO;
	public GameObject TimeGO;
	public GameObject GameTitle;
	public GameObject GameWin;

	public enum GameManagerState
	{
		Opening,
		GamePlay,
		GameOver,
		GameWin,
	}

	GameManagerState gm;
	// Use this for initialization
	void Start () {
		gm = GameManagerState.Opening;
	}

	public void StartGamePlay()
	{
		gm = GameManagerState.GamePlay;
		UpdateGameManagerState ();
	}
	public void SetGameManagerState(GameManagerState state)
	{
		gm = state;
		UpdateGameManagerState ();
	}

	public void ChangeToOpeningState()
	{
		SetGameManagerState (GameManagerState.Opening);
	}

	// Update is called once per frame
	void UpdateGameManagerState () {
		switch (gm) {
		case GameManagerState.Opening:
			PlayButton.SetActive (true);
			GameTitle.SetActive (true);
			GameWin.SetActive (false);
			GameOver.SetActive (false);
			break;
		case GameManagerState.GamePlay:
			PlayButton.SetActive (false);
			GameTitle.SetActive (false);
			TextScoresGO.GetComponent<ScoresScript> ().Scores = 00;
			fighterShip.GetComponent<fighterShipControls> ().Init ();
			enemySpawnner.GetComponent<enemySpawnner> ().ScheduleEnemySpawnner ();
			TimeGO.GetComponent<TimeCounter> ().StartTimeCounter ();
			break;

		case GameManagerState.GameOver:
			enemySpawnner.GetComponent<enemySpawnner> ().UnScheduleEnemySpawnner ();
			TimeGO.GetComponent<TimeCounter>().StopTimeCounter();
			GameOver.SetActive (true);
			Invoke("ChangeToOpeningState", 8f);
			break;
		case GameManagerState.GameWin:
			enemySpawnner.GetComponent<enemySpawnner> ().UnScheduleEnemySpawnner ();
			TimeGO.GetComponent<TimeCounter> ().StopTimeCounter ();
			GameWin.SetActive (true);
			Invoke ("ChangeToOpeningState", 8f);
			break;
		default:
			break;			
		}
	}
}
