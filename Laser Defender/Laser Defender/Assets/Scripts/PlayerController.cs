using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float padding = 1f;
	public GameObject projectile;
	public float projectileSpeed = 1f;
	public float firingRate = 1f;
	public float health = 250f;
	public AudioClip fireSound;
	public AudioClip deathSound;

	private float xMax, xMin;

	void Start ()
	{

		float distance = (transform.position.z) - (Camera.main.transform.position.z);
		Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;
	}

	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
//			transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);

			transform.position += Vector3.left * speed * Time.deltaTime;

		} else if (Input.GetKey (KeyCode.RightArrow)) {
//			transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);

			transform.position += Vector3.right * speed * Time.deltaTime;

		}
//		Restric the player to the Game space
		float newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.0000001f, firingRate);
		} 

		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}
	}

	void Fire ()
	{
		GameObject laserBeam = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		laserBeam.rigidbody2D.velocity = new Vector3 (0f, projectileSpeed, 0f);
		AudioSource.PlayClipAtPoint (fireSound, transform.position);
		
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		//		Debug.Log (collider);
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			missile.Hit ();
			health -= missile.GetDamage ();
			if (health <= 0) {
				Destroy (gameObject);
				AudioSource.PlayClipAtPoint (deathSound, transform.position);
			}
			//			Debug.Log ("Hit by missile");
		}
	}
}

