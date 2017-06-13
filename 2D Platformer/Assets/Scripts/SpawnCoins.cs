using UnityEngine;
using System.Collections;

public class SpawnCoins : MonoBehaviour
{

	public Transform[] coinsSpawns;
	public GameObject coin;

	void Start ()
	{
		Spawn ();
	}

	void Spawn ()
	{
		for (int i = 0; i < coinsSpawns.Length; i++) {
			int coinFlip = Random.Range (0, 2);
			if (coinFlip > 0) {
				Instantiate (coin, coinsSpawns [i].position, Quaternion.identity);
			}
		}
	}
}
