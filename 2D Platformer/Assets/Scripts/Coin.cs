using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Coin : MonoBehaviour
{
	public static int coinCount = 0;

	public Text coinsToGo;

	void Start ()
	{
		coinCount++;

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			coinCount--;

			Destroy (gameObject);
		}
	}


}
