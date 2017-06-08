using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	public void LoadLevel (string name)
	{
		Brick.breakableCount = 0;
		//Debug.Log ("Level load requested for " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest (string name)
	{
		//Debug.Log ("Quit request from " + name);
		Application.Quit ();
	}

	public void LoadNextLevel ()
	{
		Brick.breakableCount = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void BrickDestroyed ()
	{
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}
}
