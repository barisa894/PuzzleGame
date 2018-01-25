using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	//public string mainMenu;

	public bool isPaused; //the game is paused or not paused
	//public GameController gm;
	public GameObject pauseMenuCanvas;

	// Update is called once per frame
	void Update () {
		if (isPaused) {

			//gm.btns [firstGuessIndex].interactable = false; // buttons disable after we are choosing two puzzles.When we don't want to touch the puzzles,we have to disable our buttons interactable 
			//gm.btns [secondGuessIndex].interactable = false;
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} else 
		{
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			PauseUnpause();
		}

	}

	public void PauseUnpause()
	{
		isPaused = !isPaused;
	}

	public void Resume()
	{
		isPaused = false;
	}

	/*public void Quit()
	{
		SceneManager.LoadScene (mainMenu);
	}*/
}
