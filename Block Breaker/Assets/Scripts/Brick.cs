using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	private LevelManager levelManager;
	private int timesHit;

	public Sprite[] hitSprites;

	// Use this for initialization
	void Start ()
	{
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	
	}

	void OnCollisionExit2D (Collision2D col)
	{
		bool isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits ()
	{

		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}

	}


	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}

	// TODO 
	void SimulateWin ()
	{
		levelManager.LoadNextLevel ();
	}
}
