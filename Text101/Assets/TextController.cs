using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;

	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;

    // Use this for initialization
    void Start() {
        myState = States.cell;
    }

    // Update is called once per frame
    void Update() {
		print (myState);

		if (myState == States.cell) {
			state_Cell();
		} else if (myState == States.sheets_0) {
			state_Sheets_0();
		} else if (myState == States.lock_0) {
			state_Lock_0();
		} else if (myState == States.mirror) {
			state_Miirror();
		} else if (myState == States.cell_mirror) {
			state_Cell_Mirror();			
		} else if (myState == States.sheets_1) {
			state_Sheets_1();
		} else if (myState == States.lock_1) {
			state_Lock_1();
		} else if (myState == States.freedom) {
			state_Freedom();
		}
    }
#region State handler methods
	void state_Cell() {
		  text.text = "You wake up… Seems just a normal morning at the prison... Prison…?! You don’t remember being a convicted… Where are you exactly…? You feel confused… " +
			"But how you ended up in here?! You can hear other prisoners but, you can’t see them, at least in the cells right in front of you there is nobody… You stop and look around… " +
			"Ok… It seems a regular cell, a double bed with sheets on it, a toilet with a mirror on top of it, and lock of your cell. Nothing unusual… For a prison cell. \n\n" +
			"Press S to view Sheets, M to view Mirror and L to view Lock.";
			if (Input.GetKeyDown(KeyCode.S)) {
				myState = States.sheets_0;
			} else if (Input.GetKeyDown(KeyCode.L)) {
				myState = States.lock_0;
			} else if (Input.GetKeyDown(KeyCode.M)) {
				myState = States.mirror;
			}
	}

	void state_Sheets_0() {
		text.text = "Did you sleep in that? Looks filthy… Surely it is time somebody changed them! The pleasures of prison life… I guess... Still, nothing in there… \n\n" +
					"Press R to Return to roaming your cell.";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_Lock_0() {
		text.text = "You look at the lock of your cell… Strangely your cell is locked by a padlock. Is the lock not working? You try to move it, but it won’t budge… \n\n" + 
					"Press R to Return to roaming your cell.";
		 if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_Miirror() {
		text.text = "As you get close to the mirror, you notice as it seems oddly positioned… Not only crooked… Slanting to the right, but out of context… \n\n" + 
					"Press T to take the mirror, or R to return roaming the cell.";
					if(Input.GetKeyDown(KeyCode.R)) {
						myState = States.cell;
					} else if (Input.GetKeyDown(KeyCode.T)) {
						myState = States.cell_mirror;
						}
				}
		
	void state_Cell_Mirror() {
		text.text = "You take the mirror. As you grabbed it, something fell of behind of it. Start searching, and you see it fell behind the toilet. " +
					"You grasp to grab it, but as you touch it, you chill as you know it is your way out… It is a key! Who left it in there? Why me? No time for questions, you want your freedom! \n" +
					"You look around… \n\n" +
					"Press S to view Sheets or L to view Lock.";
					if(Input.GetKeyDown(KeyCode.S))  {
						myState = States.sheets_1;
					} else if (Input.GetKeyDown(KeyCode.M)) {
						myState = States.lock_1;
					}
	}

	void state_Sheets_1() {
		text.text = "As you look to the sheets you know there is nothing else there for you there... \n\n" +
					"Press L to view the Lock or R to return to Roaming the room";
					if(Input.GetKeyDown(KeyCode.L)) {
						myState = States.lock_1;
					} else if (Input.GetKeyDown(KeyCode.R)) {
						myState = States.cell_mirror;
					}
	}

	void state_Lock_1() {
		text.text = "You run to the lock, as you try, nervously, to put the key in the padlock… It fits!!! \n\n" + 
					"Press O to Open the lock.";
					if(Input.GetKeyDown(KeyCode.O)) {
						myState = States.freedom;
					}
	}

	void state_Freedom() {
			text.text = "You turn the key and hear a click as the padlock unlocks... You release it and it feels to the ground. You hear the noise, it is loud! But you don't seem to care." +
						"You open the gate and step outside, you feel the freedom! But as you look around, the prison is empty!! Where are you?! \n\n" + 
						"Press Space to restart."; 
						if (Input.GetKeyDown(KeyCode.Space)) {
							myState = States.cell;
						}

	}
#endregion
}
