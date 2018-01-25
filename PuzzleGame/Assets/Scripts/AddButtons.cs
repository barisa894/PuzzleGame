using UnityEngine;
using System.Collections;

public class AddButtons : MonoBehaviour {

	[SerializeField]
	private Transform puzzleField;

	[SerializeField]
	private GameObject btn;
	void Awake() 
	{
		for (int i = 0; i< 20; i++){
			GameObject button = Instantiate (btn);
			button.name = "" + i; //indexes for buttons 1,2,3 etc. 
			button.transform.SetParent(puzzleField, false);
	}


	}
}

