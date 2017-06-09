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
	public GameObject smoke;

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
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.5f);
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
			SmokePuff ();
			Destroy (gameObject);

		} else {
			LoadSprites ();
		}

	}

	void SmokePuff ()
	{
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		} else {
			Debug.LogError (" Brick sprite missing! ");
		}
	}

	// TODO 
	void SimulateWin ()
	{
		levelManager.LoadNextLevel ();
	}
}
