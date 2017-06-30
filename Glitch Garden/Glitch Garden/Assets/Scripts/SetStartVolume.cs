using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour
{
	private MusicManager musicManager;

	void Start ()
	{
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		if (musicManager) {
			float volume = PlayerPrefsManager.GetMasterVolume ();
			musicManager.SetVolume (volume);
//			Debug.Log ("Found the manager " + musicManager);
		} else {
			Debug.LogWarning ("No music manager found in scene. Can't set volume");
		}
	}
}
