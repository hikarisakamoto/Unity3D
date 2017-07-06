using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Lizard : MonoBehaviour
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

		if (!gObj.GetComponent<Defender> ()) {
			return;
		}

		animator.SetBool ("isAttacking", true);
		attacker.Attack (gObj);
	}
}
