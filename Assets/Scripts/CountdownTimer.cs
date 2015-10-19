using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour {

	public Text label;
	
	bool timing;
	double countdown;

	// Use this for initialization
	void Start () {
		start_timer(300.00);
	}
	
	// Update is called once per frame
	void Update () {
		if (timing) {
			countdown -= Time.deltaTime;
			label.text = string.Format("\n{0:0} seconds", countdown);
			if (countdown <= 0.00) {
				label.text = "Game Over";
				timing = false;
			}
		}
	}
	
	void start_timer(double time) {
		timing = true;
		countdown = time;
	}
}
