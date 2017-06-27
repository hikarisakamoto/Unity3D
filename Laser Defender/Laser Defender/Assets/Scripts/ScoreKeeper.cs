using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour
{
	public int score;

	private Text scoreText;
	void Start ()
	{
		scoreText = GetComponent<Text> ();
	}

	public void Score (int points)
	{
		score += points;
		scoreText.text = "Score: " + score.ToString ();
	}

	public void Reset ()
	{
		score = 0;
	}
}
