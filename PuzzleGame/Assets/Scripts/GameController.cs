using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


	static public int score;
	static public int total_guesses;

	//public float startingTime;
	//private Text timerText;

	public Text scoreText;
	public Text total_guessesText;
	[SerializeField]
	private Sprite bgImage;

	public Sprite[] puzzles;

	public List<Sprite>gamePuzzles = new List<Sprite>();

	public List<Button> btns = new List<Button>(); //list is a generic

	private bool firstGuess, secondGuess; //initially false

	private int countGuesses;
	private int countCorrectGuesses;
	private int gameGuesses;

	private int firstGuessIndex, secondGuessIndex;

	private string firstGuessPuzzle, secondGuessPuzzle;

	void Awake()
	{
		puzzles = Resources.LoadAll<Sprite> ("Sprites"); //file path
		}
	// Use this for initialization
	void Start() {
		GetButtons ();
		AddListeners ();
		AddGamePuzzles ();
		gameGuesses = gamePuzzles.Count / 2;
		Shuffle (gamePuzzles);
	//	timerText = GetComponent<Text> ();

	
	}
	
	// Update is called once per frame
	void GetButtons () {
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("PuzzleButton"); // getting gameobject

		for (int i = 0; i < objects.Length; i++) {
			btns.Add (objects [i].GetComponent<Button> ());
			btns [i].image.sprite = bgImage; // background image
		}
	
	}

	void AddGamePuzzles() {

		int looper = btns.Count; //how many buttons we have
		int index = 0;

		for (int i = 0; i < looper; i++) {
			if (index == looper / 2) { // we want to add two same puzzle pieces
				index = 0;
			}
			gamePuzzles.Add (puzzles [index]); 

			index++;
		}
	}
			
	void AddListeners()
	{
			
		foreach (Button btn in btns) 
		{
			btn.onClick.AddListener (() => PickAPuzzle());
		}
			
	}

	public void PickAPuzzle ()
	{
		string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		Debug.Log ("You Are Clicking A Button named" + name);

		if (!firstGuess) {
			firstGuess = true;
			firstGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name); // to convert from string to integer
			firstGuessPuzzle = gamePuzzles [firstGuessIndex].name;
			btns [firstGuessIndex].image.sprite = gamePuzzles [firstGuessIndex];
			//total_guesses++;

		} else if (!secondGuess) {
			secondGuess = true;
			secondGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
			secondGuessPuzzle = gamePuzzles [secondGuessIndex].name;// to convert from string to integer
			btns [secondGuessIndex].image.sprite = gamePuzzles [secondGuessIndex];
			total_guesses++;
			StartCoroutine (CheckIfThePuzzlesMatch ());
		}
	}

	IEnumerator CheckIfThePuzzlesMatch (){
		yield return new WaitForSeconds (1f);

		if (firstGuessPuzzle == secondGuessPuzzle && firstGuessIndex != secondGuessIndex) {
			yield return new WaitForSeconds (.5f);
			btns [firstGuessIndex].interactable = false; // buttons disable after we are choosing two puzzles.When we don't want to touch the puzzles,we have to disable our buttons interactable 
			btns [secondGuessIndex].interactable = false;

			btns [firstGuessIndex].image.color = new Color (0, 0, 0, 0); // invisible (alpha color)We don't want to see buttons in the scene anymore
			btns [secondGuessIndex].image.color = new Color (0, 0, 0, 0);

			score++;
			//total_guesses++;
			//total_guessesText.text = "Total Guesses " + total_guesses;

			scoreText.text = "Score: " + score;
			
			CheckIfTheGameIsFinished ();
		
		} else {
			yield return new WaitForSeconds (.5f);

			btns [firstGuessIndex].image.sprite = bgImage; // invisible (alpha color)
			btns [secondGuessIndex].image.sprite = bgImage; 
		}

		yield return new WaitForSeconds (.5f);

		firstGuess = secondGuess = false; // to reset




	}
	void CheckIfTheGameIsFinished() {
		countCorrectGuesses++; 
		//score++;//correct guesses count by one
		//total_guesses++;
		if(countCorrectGuesses == gameGuesses) {
			SceneManager.LoadScene(2);
			Debug.Log ("Game Finished");
			Debug.Log("It took you " + countGuesses + " many guess(es) to finish the game");
			total_guessesText.text = "Total Guesses " + total_guesses;
				

}
				}
	void Shuffle(List<Sprite> list) {
		for (int i = 0; i < list.Count; i++) {

			Sprite temp = list [i];
			int randomIndex = Random.Range (i, list.Count); // random index between i and less than list.count
			list [i] = list [randomIndex];
			list [randomIndex] = temp;
	}
}
}


