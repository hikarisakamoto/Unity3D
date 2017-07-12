﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour
{
	public enum Status
	{
		SUCCES,
		FAILURE
	}
	;

	private Text starText;
	private int stars = 100;

	void Start ()
	{
		starText = GetComponent<Text> ();
		UpdateDisplay ();
	}

	public void AddStars (int amount)
	{
//		print (amount + " stars added to display");
		stars += amount;
		UpdateDisplay ();
	}

	public Status UseStars (int amount)
	{
		//		print (amount + " stars added to display");
		if (stars >= amount) {
			stars -= amount;
			UpdateDisplay ();
			return Status.SUCCES;
		}
		return Status.FAILURE;
	}

	private void UpdateDisplay ()
	{
		starText.text = stars.ToString ();
	}
}
