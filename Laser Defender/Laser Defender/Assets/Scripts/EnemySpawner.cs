using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public float width = 10f;
	public float hight = 5f;
	public float speed = 5f;
	public float spawnDelay = 0.5f;

	private bool movingRight = true;
	private float xMax;
	private float xMin;

	void Start ()
	{
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distanceToCamera));
		
		xMax = rightBoundary.x;
		xMin = leftBoundary.x;

		SpawnUntilFull ();
	}

	public void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, hight));
	}

	void Update ()
	{
		if (movingRight) {
			transform.position += (Vector3.right * speed * Time.deltaTime); 

		} else {
			transform.position += (Vector3.left * speed * Time.deltaTime); 
		}

		float rightEdgeOfFormation = transform.position.x + (0.5f * width);
		float leftEdgeOfFormation = transform.position.x - (0.5f * width);


		if (leftEdgeOfFormation < xMin) {
			movingRight = true;
		} else if (rightEdgeOfFormation > xMax) {
			movingRight = false;
		}		 

		if (AllMembersDead ()) {
			Debug.Log ("Empty Formation");
			SpawnUntilFull ();
		}
	}

	bool AllMembersDead ()
	{
		foreach (Transform childPostionGameObject in transform) {
			if (childPostionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	Transform NextFreePosition ()
	{
		foreach (Transform childPostionGameObject in transform) {
			if (childPostionGameObject.childCount == 0) {
				return childPostionGameObject;
			}
		}
		return null;
	}

	void SpawnEnemies ()
	{		
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnUntilFull ()
	{
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if (NextFreePosition ()) {
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}

}
