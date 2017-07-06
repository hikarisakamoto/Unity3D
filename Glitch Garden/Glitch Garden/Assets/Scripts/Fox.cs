using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour
{
	private Animator animator;
	private Attacker attacker;

	void Start ()
	{
		animator = GetComponent<Animator> ();
		attacker = GetComponent<Attacker> ();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		GameObject gObj = collider.gameObject;

		// Leave the method if not colliding with defender
		if (!gObj.GetComponent<Defender> ()) {
			return;
		}

		if (gObj.GetComponent<Stone> ()) {
//			Debug.Log ("Fox collided with " + collider);
			animator.SetTrigger ("jumpTrigger");
		} else {
//			Debug.Log ("Fox collided with " + collider);
			animator.SetBool ("isAttacking", true);
			attacker.Attack (gObj);
		}
	}
}
