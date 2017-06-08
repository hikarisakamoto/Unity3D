using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;

	public AudioClip crack;
	public static int breakableCount = 0;
	public Sprite[] hitSprites;

	// Use this for initialization
	void Start ()
	{
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{	
	}

	void OnCollisionExit2D (Collision2D col)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits ()
	{

		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed ();
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
