using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	bool pressed;
	bool maxDown;


	// Use this for initialization
	void Start () {

		pressed=false;

	}

	void Update () {

		CheckInput();
		HandleRotation();

	}

	void CheckInput(){

		if(Input.anyKey==true) pressed=true;
		//if(Input.GetTouch==true) pressed=true;			LOOK MA! MOBILE INPUT!
		else pressed = false;

	}

	void HandleRotation(){

						//Not pressed, tilt nose up
		if(!pressed){  
			if (transform.eulerAngles.z>=89 && transform.eulerAngles.z<100) transform.eulerAngles = new Vector3(0,0,89);
			else transform.Rotate(Vector3.forward * Time.deltaTime * 300);
		}
						//Pressed, tilt nose down
		else{
			if (transform.eulerAngles.z<=271 && transform.eulerAngles.z>100) transform.eulerAngles = new Vector3(0,0,271);
			else transform.Rotate(Vector3.back * Time.deltaTime * 175);
		}
	}
}
