using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public GameObject[] attackerPrefabArray;

	void Update ()
	{
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}

	void Spawn (GameObject myGameObject)
	{
		GameObject attacker = Instantiate (myGameObject) as GameObject;
		attacker.transform.parent = transform;
		attacker.transform.position = transform.position;
	}

	bool isTimeToSpawn (GameObject attackerGameObject)
	{
		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();

		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnPerSeconds = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		} 

		float threshold = spawnPerSeconds * Time.deltaTime / 5;

		return (Random.value < threshold);

	}
}
