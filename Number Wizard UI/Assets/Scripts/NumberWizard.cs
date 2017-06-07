using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
	// Use this for initialization
	int max;
	int min;
	int guess;

	public int maxGuessesAllowed = 5;

	public Text guessText;

	void Start ()
	{
		StartGame ();
	}

	void StartGame ()
	{
		max = 1000;
		min = 1;
		nextGuess ();

	}


	// Update is called once per frame
	void Update ()
	{
		// Empty 
	}

	public void guessHigher ()
	{
		min = guess;
		nextGuess ();
	}

	public void guessLower ()
	{
		max = guess;
		nextGuess ();
	}

	void nextGuess ()
	{
		guess = Random.Range (min, max + 1);
		maxGuessesAllowed--;

		guessText.text = guess.ToString ();

		if (maxGuessesAllowed == 0) {
			Application.LoadLevel ("Win");
		}
	}

	public void youLose ()
	{
		Application.LoadLevel ("Lose");
	}


}