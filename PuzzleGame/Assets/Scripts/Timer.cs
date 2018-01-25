using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
	public float startingTime;
	public Text timerText;
	//[SerializeField]
	//private GameController gm;

	// Use this for initialization
	void Start () {
		timerText = GetComponent<Text> ();
	//	gm = GetComponent<GameController> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		startingTime -= Time.deltaTime;
		timerText.text = "" + Mathf.Round (startingTime);
		if (startingTime <= 0) {
			//	gameOverScreen.SetActive (true);
			//	paddle.gameObject.SetActive (false);
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			SceneManager.LoadScene(0);
			Debug.Log ("Game Over");

		}
	}
}
