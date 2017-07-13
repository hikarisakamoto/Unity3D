using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour
{
	public float levelSeconds = 100;

	private AudioSource audioSource;
	private Slider slider;
	private bool isEndOfLevel = false;
	private LevelManager levelManager ;
	private GameObject winLabel;

	void Start ()
	{
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		FindYouWin ();
	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("Please create a You Win object!");
		} else {
			winLabel.SetActive (false);
		}
	}

	void Update ()
	{
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel) {
			HandleWinCondition ();
		}
	}

	void HandleWinCondition ()
	{
		//			print ("Level over.");
		DestroyAllTaggedObjects ();
		audioSource.Play ();
		winLabel.SetActive (true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
		isEndOfLevel = true;
	}

	// Destroys all objects with destroyOnWin tag
	void DestroyAllTaggedObjects ()
	{
		GameObject[] taggedObjectsArray = GameObject.FindGameObjectsWithTag ("destroyOnWin");

		foreach (GameObject taggedObject in taggedObjectsArray) {
			Destroy (taggedObject);
		}
	}

	void LoadNextLevel ()
	{
		levelManager.LoadNextLevel ();
	}
}
