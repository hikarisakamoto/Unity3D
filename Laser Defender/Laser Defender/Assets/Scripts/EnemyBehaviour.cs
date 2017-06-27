using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
	public float health = 150f;
	public GameObject projectile;
	public float projectileSpeed = 10f;
	public float shotsPerSeconds = 0.3f;
	public int scoreValue = 150;

	public AudioClip fireSound;
	public AudioClip destroySound;

	private ScoreKeeper scoreKeeper;


	void Start ()
	{
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
	}

	
	void Update ()
	{
		float probability = shotsPerSeconds * Time.deltaTime;
		if (Random.value < probability) {
			Fire ();
		}
	}


	void OnTriggerEnter2D (Collider2D collider)
	{
//		Debug.Log (collider);
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			missile.Hit ();
			health -= missile.GetDamage ();
			if (health <= 0) {
				Death ();
			}
//			Debug.Log ("Hit by missile");
		}
	}


	void Fire ()
	{
		GameObject missile = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2 (0f, -projectileSpeed);
		AudioSource.PlayClipAtPoint (fireSound, transform.position);
	}


	void Death ()
	{
		AudioSource.PlayClipAtPoint (destroySound, transform.position);
		Destroy (gameObject);
		scoreKeeper.Score (scoreValue);
	}
}
