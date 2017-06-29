using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour
{
	public float fadeInTime;

	private Image fadePanel;
	private Color currentColor = Color.black;

	void Start ()
	{
		fadePanel = GetComponent<Image> ();
	}

	void Update ()
	{
		if (Time.timeSinceLevelLoad < fadeInTime) {
			float alpahaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alpahaChange;
			fadePanel.color = currentColor;
		} else {
			gameObject.SetActive (false);
		}
	}
}
