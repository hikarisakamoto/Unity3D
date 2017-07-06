using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
	public GameObject defenderPrefab;

	private Button[] buttonArray;
	public static GameObject selectedDefender;

	void Start ()
	{
		buttonArray = GameObject.FindObjectsOfType<Button> ();
	}

	void OnMouseDown ()
	{
//		Debug.Log (name + " pressed.");

		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer> ().color = Color.black;
		}
		GetComponent<SpriteRenderer> ().color = Color.white;

		selectedDefender = defenderPrefab;

//		Debug.Log (selectedDefender);
	}
}
