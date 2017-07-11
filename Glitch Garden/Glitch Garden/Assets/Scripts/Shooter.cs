using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
	public GameObject projectile, projectileLauncher;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner laneSpawner;

	void Start ()
	{
		animator = GameObject.FindObjectOfType<Animator> ();
		projectileParent = GameObject.Find ("Projectiles");

//		Creates a parent if necessary
		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles");
		}

		SetLaneSpawner ();
	}

	void Update ()
	{
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	bool IsAttackerAheadInLane ()
	{
//		 Exit if no attacker in lane
		if (laneSpawner.transform.childCount <= 0) {
			return false;
		}

//		 If there are attackers, are they ahead?
		foreach (Transform attackers in laneSpawner.transform) {
			if (attackers.transform.position.x > transform.position.x) {
				return true;
			}
		}

//		 Attackers in lane, but behind us
		return false;
	}

	// Look through all spawners, and set laneSpawner if found
	void SetLaneSpawner ()
	{
		Spawner [] spawnerArray = GameObject.FindObjectsOfType<Spawner> ();

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				laneSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + " can't find spawner in lane");
	}

	private void Fire ()
	{
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = projectileLauncher.transform.position;
	}

//	void OnBecameInvisible ()
//	{
//		Destroy (gameObject);
//	}
}
