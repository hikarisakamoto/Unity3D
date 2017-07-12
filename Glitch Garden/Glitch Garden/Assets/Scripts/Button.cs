using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour
{
	public static GameObject selectedDefender;
	public GameObject defenderPrefab;

	private Button[] buttonArray;
	private Text costText;

	void Start ()
	{
		buttonArray = GameObject.FindObjectsOfType<Button> ();
		costText = GetComponentInChildren<Text> ();

		if (!costText) {
			Debug.LogWarning (name + " has no cost text!");
		}

		costText.text = defenderPrefab.GetComponent<Defender> ().starCost.ToString ();
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
