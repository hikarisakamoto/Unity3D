using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
	static MusicPlayer instance = null;

	void Awake ()
	{
		//	Debug.Log ("Music player Awake " + GetInstanceID ());

		if (instance != null) {
			Destroy (gameObject);
			Debug.Log ("Duplicate music player destroyed!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}

	void Update ()
	{
	
	}
}
