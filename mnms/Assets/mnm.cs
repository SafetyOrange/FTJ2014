using UnityEngine;
using System.Collections;

public class mnm : MonoBehaviour {
	bool poisoned;
	// Use this for initialization
	void Start () {
		float rand = Random.Range (0, 100);
		if(rand>30 && rand<40.1f){
			poisoned = true;
			gameObject.tag = "poisoned";
		} else {
			poisoned = false;
			gameObject.tag = "safe";
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
