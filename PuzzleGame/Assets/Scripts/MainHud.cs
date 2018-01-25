using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainHud : MonoBehaviour {

	private PauseMenu thePauseMenu;

	public Text points;
	private int points_count = 0;
	public Text total_guesses;
	private int total_guesses_count = 0;
	// Use this for initialization
	void Start () {
		thePauseMenu = FindObjectOfType<PauseMenu> ();
		points_count = GameController.score;
		total_guesses_count = GameController.total_guesses;
	}

	// Update is called once per frame
	void Update () {

		points.text = points_count.ToString ();
		total_guesses.text =  total_guesses_count.ToString ();
	}
	public void PlayAgain()
	{
		SceneManager.LoadScene(1);
		GameController.score = 0;
	}
	public void Pause()
	{
		//Debug.Log ("Paused");
		thePauseMenu.PauseUnpause ();

		//thePauseMenu.isPaused = !thePauseMenu.isPaused;
	}
}
