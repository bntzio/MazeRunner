using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameEngine : MonoBehaviour {

	public Text label;
	
	private enum States {
							welcome_screen, room_0, room_1, corridor, axe, wooden_door, door_0, door_1, door_2, door_3, door_4, door_5, door_6,
							door_7, table_0, table_1, rock, bushes, garden, box, tinderbox, jail, computer_0, computer_1,
							code_0, code_1, safe, key_0, key_1, forest, trees, wardrove, clothes, message, exit, game_over
						}
						
	private States myState;
	
	int switch_corridor_state, switch_wooden_door_state, switch_door_0_state, switch_door_1_state,
		switch_door_2_state, switch_door_3_state, switch_door_4_state, switch_door_5_state,
		switch_door_6_state, switch_door_7_state, switch_forest_state = 0;
		
	bool timing;
	double countdown;
	bool random_switch = true;
	int rnd_number;

	// Use this for initialization
	void Start () {
		myState = States.welcome_screen;
		start_timer(300.00);
	}
	
	// Update is called once per frame
	void Update () {
		print(myState);
		print(countdown);
		print(rnd_number);
		
		if 		(myState == States.welcome_screen)	{state_welcome_screen();}		
		else if (myState == States.room_0)			{state_room_0();}
		else if (myState == States.room_1)			{state_room_1();}
		else if (myState == States.corridor)		{state_corridor();}
		else if (myState == States.axe)				{state_axe();}
		else if (myState == States.wooden_door)		{state_wooden_door();}
		else if (myState == States.door_0)			{state_door_0();}
		else if (myState == States.door_1)			{state_door_1();}
		else if (myState == States.door_2)			{state_door_2();}
		else if (myState == States.door_3)			{state_door_3();}
		else if (myState == States.door_4)			{state_door_4();}
		else if (myState == States.door_5)			{state_door_5();}
		else if (myState == States.door_6)			{state_door_6();}
		else if (myState == States.door_7)			{state_door_7();}
		else if (myState == States.table_0)			{state_table_0();}
		else if (myState == States.table_1)			{state_table_1();}
		else if (myState == States.rock)			{state_rock();}
		else if (myState == States.bushes)			{state_bushes();}
		else if (myState == States.garden)			{state_garden();}
		else if (myState == States.box)				{state_box();}
		else if (myState == States.tinderbox)		{state_tinderbox();}
		else if (myState == States.jail)			{state_jail();}
		else if (myState == States.computer_0)		{state_computer_0();}
		else if (myState == States.computer_1)		{state_computer_1();}
		else if (myState == States.code_0)			{state_code_0();}
		else if (myState == States.code_1)			{state_code_1();}
		else if (myState == States.safe)			{state_safe();}
		else if (myState == States.key_0)			{state_key_0();}
		else if (myState == States.key_1)			{state_key_1();}
		else if (myState == States.code_0)			{state_code_0();}
		else if (myState == States.forest)			{state_forest();}
		else if (myState == States.trees)			{state_trees();}
		else if (myState == States.wardrove)		{state_wardrove();}
		else if (myState == States.clothes)			{state_clothes();}
		else if (myState == States.message)			{state_message();}
		else if (myState == States.exit)			{state_exit();}
		else if (myState == States.game_over)		{state_game_over();}
		
		if (timing) {
			countdown -= Time.deltaTime;
			if (countdown <= 0.00) {
				myState = States.game_over;
				timing = false;
			}
		}
	}
	
	// welcome_screen state
	void state_welcome_screen() {
		label.text = "Press Spacebar to enter the maze...\n" +
					 "Be careful, please!";
		if (Input.GetKeyDown(KeyCode.Space))		{myState = States.room_0;}
	}
	
	
	// game over message
	void state_game_over() {
		if (random_switch == true) {
			rnd_number = Random.Range(1,5);
			random_switch = false;
		}
		if 		(rnd_number == 1)			{label.text = "You Lost!\nThe monster is eating your brain...";}
		else if (rnd_number == 2)			{label.text = "You Lost!\nThe monster is eating your heart...";}
		else if (rnd_number == 3)			{label.text = "You Lost!\nThe monster is beating you to death...";}
		else if (rnd_number == 4)			{label.text = "You Lost!\nThe monster is celebrating your death...";}
		else if (rnd_number == 5)			{label.text = "You Lost!\nThe monster is stabbing you in the heart...";}
	}
	
	// countdown timer
	void start_timer(double time) {
		timing = true;
		countdown = time;
	}
	
	// room_0 state
	void state_room_0() {
		label.text = "You are in a room, and you can see a corridor in front of you...\n\n" +
					 "Press C to go to the Corridor";
		if (Input.GetKeyDown(KeyCode.C))			{myState = States.corridor;}
	}
	
	// room_1 state
	void state_room_1() {
		label.text = "You're in a red room, you see a table, a computer and a wardrove. " + 
					 "Mmm... and there's a strange smell in the room.\n\n" + 
					 "Press T to view the Table, C to use the Computer, W to open the Wardrove or R to Return";
		if 		(Input.GetKeyDown(KeyCode.T))		{myState = States.table_1;}
		else if (Input.GetKeyDown(KeyCode.C))		{myState = States.computer_0;}
		else if (Input.GetKeyDown(KeyCode.W))		{myState = States.wardrove;}
		else if (Input.GetKeyDown(KeyCode.R))		{myState = States.wooden_door;}
	}
	
	// corridor state
	void state_corridor() {
		if (switch_corridor_state == 0) {
			label.text = "There's a wooden door, maybe is the exit? You closely look at everything " + 
						 "inside the corridor with detail, wishing the place is safe, and you are " + 
						 "wondering why is an axe in the corridor?\n\n" + 
					 	 "Press A to take Axe, or R to Return to the room";
			if 		(Input.GetKeyDown(KeyCode.A))		{myState = States.axe;}
			else if (Input.GetKeyDown(KeyCode.R))		{myState = States.room_0;}
		} else {
			label.text = "You got the axe, now take that door down now!\n\n" +
						 "Press A to use the Axe on the door";
			if (Input.GetKeyDown(KeyCode.A)) {
				myState = States.wooden_door;
			}
		}
	}
	
	// axe state
	void state_axe() {
		switch_corridor_state = 1;
		label.text = "You grab the axe, and put it inside your bag.\n\n" + 
					 "Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R))			{myState = States.corridor;}
	}
	
	// wood_door state
	void state_wooden_door() {
		if (switch_wooden_door_state == 0) {
			label.text = "You destroyed the door and... Wow, there are 4 doors, now what?\n\n" +
						 "Press 1 to open the first door, 2 to open the second one and so on...";
			if 		(Input.GetKeyDown(KeyCode.Alpha1))	{myState = States.door_0;}
			else if (Input.GetKeyDown(KeyCode.Alpha2))	{myState = States.door_1;}
			else if (Input.GetKeyDown(KeyCode.Alpha3))	{myState = States.door_2;}
			else if (Input.GetKeyDown(KeyCode.Alpha4))	{myState = States.door_3;}
		} else {
			label.text = "There are 4 doors, now what?\n\n" +
						 "Press 1 to open the first door, 2 to open the second one and so on...";
			if 		(Input.GetKeyDown(KeyCode.Alpha1))	{myState = States.door_0;}
			else if (Input.GetKeyDown(KeyCode.Alpha2))	{myState = States.door_1;}
			else if (Input.GetKeyDown(KeyCode.Alpha3))	{myState = States.door_2;}
			else if (Input.GetKeyDown(KeyCode.Alpha4))	{myState = States.door_3;}
		}
	}
	
	// door_0 state
	void state_door_0() {
		if (switch_door_2_state == 0) {
			switch_wooden_door_state = 1;
			label.text = "You look around and what you see is table, a rock and some bushes.\n\n" + 
						 "Press T to look down the Table, I to Inspect the rock, B to search in bushes" + 
						 "or R to Return";
			if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.wooden_door;}
			else if (Input.GetKeyDown(KeyCode.T))		{myState = States.table_0;}
			else if (Input.GetKeyDown(KeyCode.I))		{myState = States.rock;}
			else if (Input.GetKeyDown(KeyCode.B))		{myState = States.bushes;}
		} else {
			switch_wooden_door_state = 1;
			label.text = "You're in the room where you saw the table, the rock and the bushes.\n\n" +
						 "Press T to look down the Table, I to Inspect the rock, B to search in bushes" + 
						 "or R to Return";
			if 		(Input.GetKeyDown(KeyCode.R))		{myState = States.wooden_door;}
			else if (Input.GetKeyDown(KeyCode.T))		{myState = States.table_0;}
			else if (Input.GetKeyDown(KeyCode.I))		{myState = States.rock;}
			else if (Input.GetKeyDown(KeyCode.B))		{myState = States.bushes;}
		}
	}
	
	// door_1 state
	void state_door_1() {
		if (switch_door_1_state == 0) {
			label.text = "This door is locked.\n\n" +
						 "Press R to Return";
			if (Input.GetKeyDown(KeyCode.R))			{myState = States.wooden_door;}
		} else {
			label.text = "You try to open the door with the old dirty key... Now is open!\n\n" +
						 "Press E to enter";
			if 		(Input.GetKeyDown(KeyCode.E))		{myState = States.forest;}
		}
	}
	
	// door_2 state
	void state_door_2() {
		if (switch_door_2_state == 0) {
			label.text = "This door is locked.\n\n" + 
						 "Press R to Return";
			if (Input.GetKeyDown(KeyCode.R))			{myState = States.wooden_door;}
		} else {
			label.text = "You try to open the door with the shiny key... It's open!\n\n" + 
						 "Press E to Enter or R to Return";
			if 		(Input.GetKeyDown(KeyCode.E))		{myState = States.room_1;}
			else if (Input.GetKeyDown(KeyCode.R))		{myState = States.wooden_door;}
		}
	}
	
	// door_3 state
	void state_door_3() {
		label.text = "This door is locked.\n\n" + 
					 "Press R to Return";
		if (Input.GetKeyDown(KeyCode.R))			{myState = States.wooden_door;}
	}
	
	// door_4 state
	void state_door_4() {
		
	}
	
	// door_5 state
	void state_door_5() {
		
	}
	
	// door_6 state
	void state_door_6() {
		
	}
	
	// door_7 state
	void state_door_7() {
		
	}
	
	// table_0 state
	void state_table_0() {
		label.text = "Mmm... Just a table.\n\n" + 
					 "Press R to Return";
		if (Input.GetKeyDown(KeyCode.R))			{myState = States.door_0;}
	}
	
	// table_1 state
	void state_table_1() {
	
	}
	
	// rock state
	void state_rock() {
		label.text = "There is nothing to see in this rock, it's a simple rock.\n\n" + 
					 "Press R to Return";
		if (Input.GetKeyDown(KeyCode.R))			{myState = States.door_0;}
	}
	
	// bushes state
	void state_bushes() {
		label.text = "You are searching in the bushes... Oh! You just found a shiny key!" +
					 "Press R to Return";
		switch_door_2_state = 1;
		if (Input.GetKeyDown(KeyCode.R))			{myState = States.door_0;}
	}
	
	// garden state
	void state_garden() {
		
	}
	
	// box state
	void state_box() {
	
	}
	
	// tinderbox state
	void state_tinderbox() {
	
	}
	
	// jail state
	void state_jail() {
		
	}
	
	// computer_0 state
	void state_computer_0() {
		
	}
	
	// computer_1 state
	void state_computer_1() {
		
	}
	
	// code_0 state
	void state_code_0() {
		
	}
	
	// code_1 state
	void state_code_1() {
		
	}
	
	// safe state
	void state_safe() {
		
	}
	
	// key_0 state
	void state_key_0() {
		
	}
	
	// key_1 state
	void state_key_1() {
		
	}
	
	// forest state
	void state_forest() {
		if (switch_forest_state == 0) {
			label.text = "Now you see a big forest, oh my..." + 
						 "a MONSTER! The monster is running to you! You see a door and some trees.\n\n" + 
						 "Press E to enter or H to Hide in the trees";
			if 		(Input.GetKeyDown(KeyCode.E))		{myState = States.door_5;}
			else if (Input.GetKeyDown(KeyCode.H))		{myState = States.trees;}
		} else {
			label.text = "The monster is running to you! You see a door and some trees.\n\n" + 
					"Press E to enter or H to Hide in the trees";
			if 		(Input.GetKeyDown(KeyCode.E))		{myState = States.door_5;}
			else if (Input.GetKeyDown(KeyCode.H))		{myState = States.trees;}
		}
	}
	
	// trees state
	void state_trees() {
		switch_forest_state = 1;
		label.text = "You hide in the trees, now the monster can't see you, wait... I think " + 
					 "he can, we better move!\n\n" + 
					 "Press S to Stop hiding in the trees";
		if (Input.GetKeyDown(KeyCode.S))			{myState = States.door_5;}
	}
	
	// wardrove state
	void state_wardrove() {
		
	}
	
	// clothes state
	void state_clothes() {
		
	}
	
	// message state
	void state_message() {
		
	}
	
	// exit state
	void state_exit() {
		
	}
}