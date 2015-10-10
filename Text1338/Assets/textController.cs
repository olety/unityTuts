using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textController : MonoBehaviour {

	public Text text;
	private enum State {cell, cell1, mirror, sheets0, lock0, sheets1, lock1, freedom};
	private State currState;

	// Use this for initialization
	void Start(){
		currState = State.cell;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (currState);
		switch (currState) {
			case State.cell : stateCell();			break;
			case State.sheets0 : stateSheets0();	break;
			case State.lock0 : stateLock0();		break;
			case State.mirror : stateMirror();		break;
			case State.cell1 : stateCell1();		break;
			case State.sheets1 : stateSheets1();	break;
			case State.lock1 : stateLock1();		break;
			case State.freedom : stateFreedom();	break;
			default:								break;
		}
	}
	
	void stateCell () {
		text.text = "You're a prisoner trapped in a cell and it " +
				"seems to be no way out of here. You see some sheets, " +
				"a mirror and the door is locked from outside.\n\n" +
				"[S to view Sheets, M to view Mirror, L to view Lock]";
		if (Input.GetKeyDown (KeyCode.S)) {currState = State.sheets0;} 
		else if (Input.GetKeyDown (KeyCode.M)) {currState = State.mirror;} 
		else if (Input.GetKeyDown (KeyCode.L)) {currState = State.lock0;}
	}

	void stateSheets0 () {
		text.text = "You can't believe you've slept in those things! " + 
				"Probably you won't need them after escaping from this mess.\n\n"+
				"[R to return to roaming your cell]";
		if (Input.GetKeyDown (KeyCode.R)) {currState = State.cell;}
	}

	void stateLock0 () {
		text.text = "This is one of these button locks. You've got no " + 
				"idea what the combination is. You can feel that it's " + 
				"partially covered in dirt from behind, but it's impossible " + 
				"to see where exactly. Only if there would be a way to look behind the lock... \n\n" +
				"[R to return to roaming your cell]";
		if (Input.GetKeyDown (KeyCode.R)) {currState = State.cell;}
	}
	void stateMirror () {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
				"[T to take the mirror, R to return to roaming your cell]";
		if (Input.GetKeyDown (KeyCode.T)) {currState = State.cell1;} 
		else if (Input.GetKeyDown (KeyCode.R)) {currState = State.cell;}
	}

	void stateCell1 () {
		text.text = "You've picked up the mirror, but the cell still looks bad.\n\n" +
				"[S to view Sheets, L to view Lock]";
		if (Input.GetKeyDown (KeyCode.S)) {currState = State.sheets1;} 
		else if (Input.GetKeyDown (KeyCode.L)) {currState = State.lock1;}
	}

	void stateSheets1 () {
		text.text = "Yep. They look about the same in the mirror. No magic here.\n\n" + 
				"[R to return to roaming your cell]";
		if (Input.GetKeyDown (KeyCode.R)) {currState = State.cell1;}
	}

	void stateLock1 () {
		text.text = "You put the mirror through the bars and see where the dirt is. " +  
				"You press the dirty buttons and you hear a click!\n\n" +
				"[R to return to roaming your cell, O to open the door]";
		if (Input.GetKeyDown(KeyCode.R)) {currState = State.cell1;} 
		else if ( Input.GetKeyDown(KeyCode.O)) {currState = State.freedom;}
	}
	
	void stateFreedom () {
		text.text = "You got out of your prison! Oh wait.. Was it only a dream?..\n\n" + 
				"Press R to Restart";
		if (Input.GetKeyDown(KeyCode.R)) {currState = State.cell;} 
	}
}
