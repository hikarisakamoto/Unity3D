using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour
{
	public Camera myCamera;

	private GameObject defenderParent;

	void Start ()
	{
		defenderParent = GameObject.Find ("Defenders");

		if (!defenderParent) {
			defenderParent = new GameObject ("Defenders");
		}
	}

	void OnMouseDown ()
	{
//		Debug.Log ("Mouse position: " + Input.mousePosition);
//		Debug.Log ("World unities: " + CalculateWorldPointofMouseClick ());
//		Debug.Log ("Snap to Grid: " + SnapToGrid (CalculateWorldPointofMouseClick ()));

//		Long form... 
//		Vector2 rawPos = CalculateWorldPointofMouseClick ();
//		Vector2 roundedPos = SnapToGrid (rawPos);
//		GameObject defender = Button.selectedDefender;
//		Quaternion zeroRot = Quaternion.identity;
//		GameObject newDef =	Instantiate (defender, roundedPos, zeroRot) as GameObject;

//		Short form made by me
		GameObject newDef = Instantiate (Button.selectedDefender, SnapToGrid (CalculateWorldPointofMouseClick ()), Quaternion.identity) as GameObject;
		newDef.transform.parent = defenderParent.transform;
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos)
	{
		float newX = Mathf.RoundToInt (rawWorldPos.x);
		float newY = Mathf.RoundToInt (rawWorldPos.y);

		return new Vector2 (newX, newY);
	}

	Vector2 CalculateWorldPointofMouseClick ()
	{
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPos;
	}
}
