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
		return true;
	}
}
